using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanErectors.Common
{
    public static class StringExtensions
    {
        public static string[] Split(this string s, string separator)
        {
            return s.Split(separator.ToCharArray());
        }
		
		public static int? ParseInt(this string str)
        {
            if(int.TryParse(str, out int num))
                return num;

            return null;
        }
    }
}
