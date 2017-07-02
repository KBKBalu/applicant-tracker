using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Models
{
    public class SearchInputViewModel
    {
        public string Keyword { get; set; }
        public List<int> Status { get; set; } //Reference
      //  public List<int> Role { get; set; } //Reference
        public List<int> Company { get; set; } //Reference
        public List<int> Experience { get; set; } //String (Lower|Upprer,)
        public List<int> CreatedBy { get; set; } //Reference
        public List<int> Salary { get; set; }//String (Lower|Upprer,)
        public List<string> Location { get; set; }//String (value,)//Where to get these values to show in UI.
        public List<int> Industry { get; set; } //Reference
        public int Days { get; set; }  //Number
        

        //public bool IsRecent { get; set; }
        //public bool IsEmailAddress { get; set; }
        //public bool IsPhoneAddress { get; set; }
        //public bool IsKeyword { get; set; }
        //public string Keyword { get; set; }
        //public string Status { get; set; }
        //public string Company { get; set; }
        //public string Role { get; set; }

    }
}