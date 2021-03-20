using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Modular.NET.Core.Utilities
{
    internal static class AssemblyFinder
    {
        #region Static Methods

        internal static IEnumerable<Assembly> ScanAssemblies()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;

            var dllFiles = Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories);
            var exeFiles = Directory.EnumerateFiles(directory, "*.exe", SearchOption.AllDirectories);
            var files = dllFiles.Concat(exeFiles);

            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.Load(new AssemblyName(name));
                }
                catch (Exception)
                {
                    //
                }

                if (assembly != null)
                {
                    yield return assembly;
                }
            }
        }

        #endregion
    }
}
