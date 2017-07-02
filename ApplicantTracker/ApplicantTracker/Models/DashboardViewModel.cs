using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Models
{
    public class DashboardViewModel
    {
        public int NewProfiles { get; set; }
        public int NewInterviews { get; set; }
        public int ActiveProfiles { get; set; }
        public int OfferReleases { get; set; }
        public int TotalEmployees { get; set; }
       
    }

    public class RefreshInput
    {
        public string userId { get; set; }
        public string Role { get; set; }
        public string refreshType { get; set; }
    }

    public class DashboardRefreshViemModel
    {
        public int TotalRecords { get; set; }
        public int NewRecords { get; set; }
        public List<WeeklyActivity> WeeklyActivity { get; set; }
    }

    public class WeeklyActivity
    {
        public string UserName{get;set;}
        public int Assigned { get; set; }
        public int Closed { get; set; }
        public int InProgress { get; set; }
        public int Total { get; set; }
    }
}