using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ApplicantTracker.Data.AppTrackEntities;

namespace ApplicantTracker.Models
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        public string AlternateNumber { get; set; }
        public string Email { get; set; }
        public string SecondaryEmail { get; set; }
        public string CandidateStatus { get; set; }
        [Display(Name = "Current Employer")]
        public string CurrentEmployer { get; set; }
        [Display(Name = "Current Designation")]
        public string CurrentDesignation { get; set; }
        //[Display(Name = "Current CTC")]
        //public int CurrentCTC { get; set; }
        [Display(Name = "Current Location")]
        public string CurrentLocation { get; set; }
        [Display(Name = "Home Town")]
        public string HomeTown { get; set; }
        public string Source { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SkillSet { get; set; }
        public int ExperienceInYears { get; set; }
        public int ExperienceInMonths { get; set; }
        public string Qualification { get; set; }
        public int NoticePeriod { get; set; }
        public int SalaryInLacs { get; set; }
        public int SalaryInThousands { get; set; }
        public string AssignTo { get; set; }
        public int Industry { get; set; }

        public bool IsEdit { get; set; }


        public CandidateViewModel(candidate candidate)//Dto is better
        {
            this.CandidateId = candidate.CandidateId;
            this.CandidateStatus = "Interview Scheduled";//candidate.candidatestatu
            this.CreateDate = candidate.CreateDate;
            this.CreatedBy = candidate.CreatedBy;
            //Need to map




        }

        public CandidateViewModel()//Dto is better
        {
            //    this.CandidateId = candidate.CandidateId;
            //    this.CanidateStatus = "Interview Scheduled";//candidate.candidatestatu
            //    this.CreateDate = candidate.CreateDate;
            //    this.CreatedBy = candidate.CreatedBy;
            //Need to map




        }


    }
}