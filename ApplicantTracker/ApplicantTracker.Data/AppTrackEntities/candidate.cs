//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicantTracker.Data.AppTrackEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class candidate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public candidate()
        {
            this.profileinfoes = new HashSet<profileinfo>();
        }
    
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateNumber { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public int CanStatusId { get; set; }
        public string CurrentEmployer { get; set; }
        public string CurrentDesignation { get; set; }
        public Nullable<int> SalaryInLacks { get; set; }
        public int SalaryInThousands { get; set; }
        public Nullable<int> ExperienceYears { get; set; }
        public Nullable<int> ExperienceMonths { get; set; }
        public string Skills { get; set; }
        public int IndustryId { get; set; }
        public int NoticePeriod { get; set; }
        public int AssignedTo { get; set; }
        public byte[] Resume { get; set; }
        public string CurrentLocation { get; set; }
        public string HomeTown { get; set; }
        public string Source { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string Qualification { get; set; }
        public int Age { get; set; }
        public Nullable<System.DateTime> DateofSpoken { get; set; }
        public string PreferredLocation { get; set; }
    
        public virtual user user { get; set; }
        public virtual candidatestatu candidatestatu { get; set; }
        public virtual user user1 { get; set; }
        public virtual industry industry { get; set; }
        public virtual user user2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<profileinfo> profileinfoes { get; set; }
    }
}
