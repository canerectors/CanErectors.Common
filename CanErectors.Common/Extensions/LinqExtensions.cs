using System.Collections.Generic;
using System.Text;

namespace CanErectors.Common
{
    public static class LinqExtensions
    {
        public static string Join(this IEnumerable<string> enuml, string separator)
        {
            if (null == enuml) return string.Empty;

            var sb = new StringBuilder();

            using (var enumr = enuml.GetEnumerator())
            {
                if (enumr.MoveNext())
                {
                    sb.Append(enumr.Current);
                    while (enumr.MoveNext())
                    {
                        sb.Append(separator).Append(enumr.Current);
                    }
                }
            }

            return sb.ToString();
        }
    }
}