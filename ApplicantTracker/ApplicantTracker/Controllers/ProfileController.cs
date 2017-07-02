using ApplicantTracker.Data.AppTrackEntities;
using ApplicantTracker.InfraStructure;
using ApplicantTracker.InfraStructure.Interfaces;
using ApplicantTracker.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApplicantTracker.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IBusinessLayer _businessLayer;

        public ProfileController()
        {
            _businessLayer = new BusinessLayer();
        }

        public ProfileController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        // GET: Candidate


        //public ActionResult Edit(string candidateEmail)
        //{
        //    BusinessLayer layer = new BusinessLayer();
        //    var candidate = layer.GetProfilesByCandidateEmail(candidateEmail);
        //    var model = new ProfileViewModel(candidate[0]);
        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(ProfileViewModel model)
        //{

        //    return View();//Back to dashboard view
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post(ProfileViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        BusinessLayer layer = new BusinessLayer();
        //        try
        //        {
        //            layer.AddProfile(GetProfile(model).First());
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return View();//Need to return to dashboard View
        //}

        //[HttpPost]
        //[ActionName("SearchProfiles")]
        //public ActionResult SearchProfiles(string email)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        BusinessLayer layer = new BusinessLayer();
        //        try
        //        {
        //            var model= layer.GetProfilesByCandidateEmail(email);

        //            return View(model);
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return View();//Need to return to dashboard View
        //}


        [HttpPost]
        [Route("api/Apptrack/CreateProfile")]
        public bool Create([FromBody]ProfileViewModel model)
        {
            var userName = RequestContext.Principal.Identity.Name;
            var user = _businessLayer.GetAllEmployeesAsync().Result.Where(x => x.Email == userName).FirstOrDefault();

            Data.AppTrackEntities.profileinfo profile = new Data.AppTrackEntities.profileinfo
            {
                CreateDate = DateTime.Now,
                AppliedPositionFor = model.AppliedPositionFor,
                CompanyId = model.CompanyId,
                IndustryId = model.IndustryId.Value,
                CandidateId = model.CandidateId,
                CompanyContact = model.CompanyContact,
                CompanyDetails = model.CompanyDetails,
                ContactOfRecruiter = model.RecruiterContact,
                CreatedBy = user.UserId,
                CurrentStatus = model.CurrentStatus,
                DateOfInterview = !string.IsNullOrEmpty(model.DateOfInterview) ?
                Convert.ToDateTime(model.DateOfInterview) : default(DateTime?),
                HRCopy = model.HRCopy,
                Interviewer = model.Interviewer,
                InterviewerMobile = model.InterviewerContact,
                NameOfRecruiter = model.RecruiterName,
                ReferenceType = model.ReferenceType,
                TeamLeadName = model.TeamLeadName,
                ModifiedBy = null,
                ModifiedDate = null,

            };
            try
            {
                _businessLayer.AddProfile(profile);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        [HttpPost]
        [Route("api/Apptrack/ViewProfile")]
        public bool View([FromBody]ProfileViewModel model)
        {

            Data.AppTrackEntities.profileinfo candidate = new Data.AppTrackEntities.profileinfo
            {
                CreateDate = DateTime.Now,
                AppliedPositionFor = model.AppliedPositionFor,
                CandidateId = model.CandidateId,
                CompanyContact = model.CompanyContact,
                CompanyDetails = model.CompanyDetails,
                ContactOfRecruiter = model.RecruiterContact,
                CreatedBy = 0,
                CurrentStatus = model.CurrentStatus,
                DateOfInterview = Convert.ToDateTime(model.DateOfInterview),
                HRCopy = model.HRCopy,
                Interviewer = model.Interviewer,
                InterviewerMobile = model.InterviewerContact,
                NameOfRecruiter = model.RecruiterName,
                ReferenceType = model.ReferenceType,
                TeamLeadName = model.TeamLeadName,
                ModifiedBy = null,
                ModifiedDate = null
            };
            try
            {
                // _businessLayer.AddCandidate(candidate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("api/Apptrack/EditProfile")]
        public bool Edit([FromBody]ProfileViewModel model)
        {

            Data.AppTrackEntities.profileinfo candidate = new Data.AppTrackEntities.profileinfo
            {
                CreateDate = DateTime.Now,
                AppliedPositionFor = model.AppliedPositionFor,
                CandidateId = model.CandidateId,
                CompanyContact = model.CompanyContact,
                CompanyDetails = model.CompanyDetails,
                ContactOfRecruiter = model.RecruiterContact,
                CreatedBy = 0,
                CurrentStatus = model.CurrentStatus,
                DateOfInterview = Convert.ToDateTime(model.DateOfInterview),
                HRCopy = model.HRCopy,
                Interviewer = model.Interviewer,
                InterviewerMobile = model.InterviewerContact,
                NameOfRecruiter = model.RecruiterName,
                ReferenceType = model.ReferenceType,
                TeamLeadName = model.TeamLeadName,
                ModifiedBy = null,
                ModifiedDate = null
            };
            try
            {
                // _businessLayer.AddCandidate(candidate);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("api/Apptrack/GetProfileById")]
        public async Task<ProfileViewModel> ViewProfile(string profileId)
        {


            profileinfo profileinfo = await _businessLayer.GetProfilesByIdAsync(profileId);

            ProfileViewModel profile = new ProfileViewModel()
            {
                AppliedPositionFor = profileinfo.AppliedPositionFor,
                CandidateId = profileinfo.CandidateId,
                CompanyContact = profileinfo.CompanyContact,
                CompanyDetails = profileinfo.CompanyDetails,
                CreateDate = profileinfo.CreateDate,
                CreatedBy = profileinfo.CreatedBy,
                CurrentStatus = profileinfo.CurrentStatus,
                DateOfInterview = profileinfo.DateOfInterview != null ? profileinfo.DateOfInterview.Value.ToShortDateString() : DateTime.MinValue.ToShortDateString(),
                HRCopy = profileinfo.HRCopy,
                Interviewer = profileinfo.Interviewer,
                InterviewerContact = profileinfo.InterviewerMobile,
                ModifiedBy = profileinfo.ModifiedBy,
                ModifiedDate = profileinfo.ModifiedDate != null ? profileinfo.ModifiedDate.Value : DateTime.MinValue,
                ProfileId = profileinfo.ProfileId,
                RecruiterContact = profileinfo.ContactOfRecruiter,
                RecruiterName = profileinfo.NameOfRecruiter,
                ReferenceType = profileinfo.ReferenceType,
                TeamLeadName = profileinfo.TeamLeadName
            };

            return profile;
        }

        [HttpGet]
        [Route("api/Apptrack/FetchIndustries")]
        public async Task<List<IndustryViewModel>> FetchIndustries()
        {
            IList<industry> industries = await _businessLayer.GetAllIndustryAsync();
            //Need to call GetAllIndustries from database
            List<IndustryViewModel> industryViewModel = new List<IndustryViewModel>();
            if (industries != null && industries.Count > 0)
            {
                foreach (industry _industry in industries)
                {
                    IndustryViewModel companyVM = new IndustryViewModel()
                    {
                        IndustryId = _industry.IndustryId,
                        Name = _industry.Name,
                        Description = _industry.Description,
                        IsActive = _industry.IsActive
                    };

                    industryViewModel.Add(companyVM);
                }
            }

            return industryViewModel;
        }

        [HttpGet]
        [Route("api/Apptrack/FetchCompanies")]
        public async Task<IList<CompanyViewModel>> FetchCompanies()
        {
            IList<company> companies = await _businessLayer.GetAllCompanysAsync();
            //Need to call GetAllCompanies from database
            List<CompanyViewModel> companiesViewModel = new List<CompanyViewModel>();
            if (companies != null && companies.Count > 0)
            {
                foreach (company _company in companies)
                {
                    CompanyViewModel companyVM = new CompanyViewModel()
                    {
                        CompanyId = _company.CompanyId,
                        Name = _company.Name,
                        Description = _company.Description,
                        IsActive = _company.IsActive
                    };

                    companiesViewModel.Add(companyVM);
                }
            }

            return companiesViewModel;
        }

        private profileinfo[] GetProfile(ProfileViewModel model)
        {
            profileinfo[] candidates = new profileinfo[1];
            candidates[0] = new profileinfo
            {
                CreateDate = DateTime.Now,
                //CurrentCTC = model.CurrentCTC,
                //CurrentDesignation = model.CurrentDesignation,
                //CurrentEmployer = model.CurrentEmployer,
                //CreatedBy = HttpContext.User.Identity.Name,
                //FirstName = model.Name,
                //CurrentLocation = model.CurrentLocation,
                //Email = model.Email,
                //HomeTown = model.HomeTown,
                //MobileNumber = model.MobileNumber,
                //Source = model.Source
            };

            return candidates;
        }
    }
}