using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TemplateAppGenerator.Core
{
    public static class AssemblyInfo
    {
        static AssemblyInfo()
        {
            AssemblyConfiguration = Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyConfigurationAttribute>()
                ?.Configuration ?? string.Empty;
        }

        public static readonly string AssemblyConfiguration;
    }
}
