using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ApplicantTracker.Data.AppTrackEntities;

namespace ApplicantTracker.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }    
        public string Details { get; set; }       
        public string DOB { get; set; } //Date       
        public string Address { get; set; }      
        public string MaritalStatus { get; set; } //Enum is required?     
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public char IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public UserViewModel(user user)//Dto is better
        {
            this.UserId = user.UserId;            
            this.CreateDate = user.CreateDate;
            this.CreatedBy = user.CreatedBy;

            //Need to map
         }

    }
}