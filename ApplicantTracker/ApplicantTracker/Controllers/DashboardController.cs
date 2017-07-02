using ApplicantTracker.InfraStructure;
using ApplicantTracker.InfraStructure.Interfaces;
using ApplicantTracker.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using System.Linq;


namespace ApplicantTracker.Controllers
{
    public class DashboardController : BaseController
    {

        private readonly IBusinessLayer _businessLayer;

        public DashboardController()
        {
            _businessLayer = new BusinessLayer();
        }

        public DashboardController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet]
        [Route("api/Apptrack/GetDashboardCount")]
        public DashboardViewModel GetDashboardCount()
        {
            var totalEmployees = _businessLayer.GetAllEmployeesAsync();
            var details = _businessLayer.GetAllCandidatesAsync().Result.Where(candidate => candidate.CreateDate >= DateTime.Today.AddDays(-30)).ToList();
            DashboardViewModel count = new DashboardViewModel();
            count.ActiveProfiles = details.Where(row => row.CanStatusId != 4).Count();
            count.NewInterviews = details.Where(row => row.CanStatusId == 2).Count();
            count.OfferReleases = details.Where(row => row.CanStatusId == 3).Count();
            count.NewProfiles = details.Where(row => row.CanStatusId == 1).Count(); ;
            count.TotalEmployees = totalEmployees.Result.Count;
            return count;
        }



        [HttpPost]
        [Route("api/Apptrack/RefreshDashboard")]
        public DashboardRefreshViemModel RefreshDashboard(RefreshInput refreshType)
        {

            List<WeeklyActivity> activityList = new List<WeeklyActivity>();
            var details = new List<Data.AppTrackEntities.candidate>();
            if(refreshType.refreshType == "week")
            {
                DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
                details= _businessLayer.GetAllCandidatesAsync().Result.Where(candidate => candidate.CreateDate >= startOfWeek).ToList();
            }
            if (refreshType.refreshType == "today")
            {
                DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.Day));
                details = _businessLayer.GetAllCandidatesAsync().Result.Where(candidate => candidate.CreateDate >= startOfWeek).ToList();
            }
            if (refreshType.refreshType == "month")
            {
                DateTime startOfWeek = DateTime.Today.AddDays(-1 * 30);
                details = _businessLayer.GetAllCandidatesAsync().Result.Where(candidate => candidate.CreateDate >= startOfWeek).ToList();
            }
            List<CandidateViewModel> candidateList = new List<CandidateViewModel>();
            List<UserViewModel> userList = new List<UserViewModel>();
           
            foreach (var detail in details)
            {
                candidateList.Add(new CandidateViewModel() { CandidateId = detail.CandidateId, AssignTo = detail.AssignedTo.ToString(), CreatedBy = detail.CreatedBy, ModifiedBy = detail.ModifiedBy, CandidateStatus = detail.CanStatusId.ToString(), CreateDate = detail.CreateDate });
            }
            var users = _businessLayer.GetAllEmployees();
            foreach (var user in users)
            {
                var assigned = candidateList.Where(x=>x.AssignTo ==  user.UserId.ToString()).Count();
                var closed = candidateList.Where(x=>x.AssignTo == user.UserId.ToString() && x.CandidateStatus == "Closed").Count();
                var inprogress = candidateList.Where(x=>x.AssignTo == user.UserId.ToString() && x.CandidateStatus == "InProgress").Count();
                var total = assigned+ closed+ inprogress;
                activityList.Add(new WeeklyActivity() { UserName =string.Concat(user.FirstName," ",user.LastName), Total = total, InProgress = inprogress, Closed = closed, Assigned = assigned});
            }


            DateTime startOfWeek1= DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));

            DashboardRefreshViemModel refreshModel = new DashboardRefreshViemModel();
            refreshModel.NewRecords = candidateList.Where(row => row.CreateDate > startOfWeek1).Count();
            refreshModel.TotalRecords = candidateList.Count;
            refreshModel.WeeklyActivity = activityList;
            // DashboardRefreshViemModel refreshModel = new DashboardRefreshViemModel();
            //refreshModel.NewRecords = 100;
            //refreshModel.TotalRecords = 100;
            //refreshModel.WeeklyActivity = activityList;
            return refreshModel;
        }
    }
}