using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanErectors.Common
{
    public static class TypeExtensions
    {
        public static string PrettyTypeName(this Type t)
        {
            if (t.IsGenericType)
                return $"{t.FullName.Substring(0, t.FullName.LastIndexOf("`", StringComparison.InvariantCulture))}<{string.Join(", ", t.GetGenericArguments().Select(PrettyTypeName))}>";

            return t.FullName;
        }
    }
}
