using ApplicantTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Helpers
{
    public class Experience
    {
        Dictionary<int, string> list = new Dictionary<int, string>
        {
            { 1,"0|2"},

             { 2,"2|5"},
              { 3,"5|8"},
               { 4,"8|10"},
                { 5,"10|100"},
        };
        public string GetExperienceById(int id)
        {
            return list.Where(x => x.Key == id).Select(x => x.Value).FirstOrDefault();

        }
    }
}