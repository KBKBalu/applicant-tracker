using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Models
{
    public class SearchItemViewModel
    {

        public SearchItemViewModel()
        {
            Statuses = new List<ItemViewModel>();
          //  Roles = new List<ItemViewModel>();
            Companies = new List<ItemViewModel>();
            Experiences = new List<ItemViewModel>();
            CreatedBy = new List<ItemViewModel>();
            Salaries = new List<ItemViewModel>();
            Locations = new List<ItemViewModel>();
            Days = new List<ItemViewModel>();
            Industry = new List<ItemViewModel>();
        }
        public List<ItemViewModel> Statuses { get; set; }
        //public List<ItemViewModel> Roles { get; set; }
        public List<ItemViewModel> Companies { get; set; }
        public List<ItemViewModel> Experiences { get; set; }
        public List<ItemViewModel> CreatedBy { get; set; }
        public List<ItemViewModel> Salaries { get; set; }
        public List<ItemViewModel> Locations { get; set; }
        public List<ItemViewModel> Industry { get; set; }
        public List<ItemViewModel> Days { get; set; }
    }
}