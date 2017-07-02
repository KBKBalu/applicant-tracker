using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}