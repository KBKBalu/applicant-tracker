using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ApplicantTracker.Extensions
{
    public static class ListExtension
    {

        public static string ToString(this List<int> values, char seperator)
        {
            StringBuilder builder = new StringBuilder();

            foreach (int value in values)
            {
                builder.Append(value);
                builder.Append(seperator);
            }

            string result = builder.ToString();


            return !string.IsNullOrEmpty(result) ? result.Substring(0, result.LastIndexOf(seperator)) : null;
        }

        public static string ToString(this List<string> values, char seperator)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string value in values)
            {
                builder.Append(value);
                builder.Append(seperator);
            }

            string result = builder.ToString();


            return !string.IsNullOrEmpty(result) ? result.Substring(0, result.LastIndexOf(seperator)) : null;
        }
    }
}