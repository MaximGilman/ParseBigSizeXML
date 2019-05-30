using System;
using System.Collections.Generic;
using System.Text;

namespace CountXMLSize
{
    public static class StringExtension
    {
        public static string AddCommas(this string str)
        {
           
            return $"\"{str}\"";
        }
    }
}
