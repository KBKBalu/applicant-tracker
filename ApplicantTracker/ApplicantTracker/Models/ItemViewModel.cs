using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Models
{
    public class ItemViewModel
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public bool IsSelected { get; set; }
        public bool Show { get; set; }
    }
}