using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FIT_Api_Examples.Helper
{
    public static class Class
    {
        public static string RemoveTags(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
