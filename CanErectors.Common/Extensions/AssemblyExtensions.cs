using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CanErectors.Common
{
    public static class AssemblyExtensions
    {
        public static void EmitResources(this Assembly assembly, string resourcePattern, string basePath)
        {
            var resources = assembly.GetManifestResourceNames();

            foreach (var resource in resources.Where(r => r.Contains(resourcePattern)))
            {
                var contents = assembly.GetManifestResourceStream(resource).GetString();

                var fileName = resource.Substring(resource.IndexOf(resourcePattern, StringComparison.Ordinal));

                var filePath = Path.Combine(basePath, fileName);

                File.WriteAllText(filePath, contents);
            }
        }
    }
}
