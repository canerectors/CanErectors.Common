using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanErectors.Common
{
    public static class TypeExtensions
    {
        public static string PrettyTypeName(this Type t, bool fullName = false)
        {
            string typeName;

            if (fullName)
                typeName = t.FullName;
            else
                typeName = t.Name;

            if (t.IsGenericType)
                return $"{typeName.Substring(0, typeName.LastIndexOf("`", StringComparison.InvariantCulture))}<{string.Join(", ", t.GetGenericArguments().Select(s => s.PrettyTypeName(fullName)))}>";

            return typeName;
        }
    }
}
