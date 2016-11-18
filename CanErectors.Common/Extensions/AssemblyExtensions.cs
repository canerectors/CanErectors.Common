using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;

namespace CanErectors.Common
{
    public static class AssemblyExtensions
    {
        public static void EmitResources(this Assembly assembly, string resourcePattern, string basePath = null, bool overwriteExisting = false)
        {
            var resources = assembly.GetManifestResourceNames();

            basePath = basePath ?? PlatformServices.Default.Application.ApplicationBasePath;

            foreach (var resource in resources.Where(r => r.Contains(resourcePattern)))
            {
                var fileName = resource.Substring(resource.IndexOf(resourcePattern, StringComparison.Ordinal));

                var filePath = Path.Combine(basePath, fileName);

                if (File.Exists(filePath) && !overwriteExisting)
                    continue;

                var contents = assembly.GetManifestResourceStream(resource).GetString();

                File.WriteAllText(filePath, contents);
            }
        }
    }
}
