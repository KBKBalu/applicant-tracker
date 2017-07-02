using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantTracker.Helpers
{
    public class Salary
    {

        Dictionary<int, string> list = new Dictionary<int, string>
        {
            { 1,"0|1"},
                         { 2,"1|3"},
              { 3,"3|5"},
               { 4,"5|8"},
                { 5,"8|10"},
            { 6,"10|100"}
        };
        public string GetSalaryById(int id)
        {
            return list.Where(x => x.Key == id).Select(x => x.Value).FirstOrDefault();

        }

    }
}