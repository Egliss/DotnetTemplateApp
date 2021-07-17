using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TemplateAppGenerator.Core
{
    public static class TemplateAppGeneratorApp
    {
        static TemplateAppGeneratorApp()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            TemporaryDirectory = $"{Path.GetTempPath()}/TemplateAppGenerator/{Version}";
        }

        public static readonly string Version;
        public static readonly string TemporaryDirectory;
    }
}
