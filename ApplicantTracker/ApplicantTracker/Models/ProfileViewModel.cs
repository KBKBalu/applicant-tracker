using ApplicantTracker.Data.AppTrackEntities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Models
{
    public class ProfileViewModel
    {
        public int ProfileId { get; set; }
        public int CandidateId { get; set; }
        public string CompanyName { get; set; }
        public int? CompanyId { get; set; }
        public int? IndustryId { get; set; }
        public string CompanyDetails { get; set; }
        public string DateOfInterview { get; set; }
        public string CurrentStatus { get; set; }
        public string HRCopy { get; set; }
        public string AppliedPositionFor { get; set; }
        public string Interviewer { get; set; }
        public string InterviewerContact { get; set; }
        public string CompanyContact { get; set; }
        public string ReferenceType { get; set; }
        public string RecruiterName { get; set; }
        public string RecruiterContact { get; set; }
        public string TeamLeadName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }


        public ProfileViewModel()
        {

        }


        public ProfileViewModel(profileinfo profile)//Dto is better
        {
            this.ProfileId = profile.ProfileId;
            this.CandidateId = profile.CandidateId;
            this.CompanyId = profile.CompanyId;
            this.IndustryId = profile.IndustryId;
            this.DateOfInterview = profile.DateOfInterview != null ? profile.DateOfInterview.Value.ToShortDateString() : "";
            this.CurrentStatus = profile.CurrentStatus;
            this.HRCopy = profile.HRCopy;
            this.AppliedPositionFor = profile.AppliedPositionFor;
            this.Interviewer = profile.Interviewer;
            this.InterviewerContact = profile.InterviewerMobile;
            this.CompanyContact = profile.CompanyContact;
            this.ReferenceType = profile.ReferenceType;
            this.RecruiterName = profile.NameOfRecruiter;
            this.RecruiterContact = profile.ContactOfRecruiter;
            this.TeamLeadName = profile.TeamLeadName;
            this.CreateDate = profile.CreateDate;
            this.CreatedBy = profile.CreatedBy;
            //Need to map
        }
    }
}