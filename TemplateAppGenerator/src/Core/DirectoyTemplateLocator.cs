using System;
using System.IO;

namespace TemplateAppGenerator.Core
{
    // Templates represented by directories and files
    public class DirectoyTemplateLocator : ITemplateLocator
    {
        public string location { get; private set; }
        public string GetRaw()
        {
            return File.ReadAllText(location);
        }

        public ITemplateLocator ToTemporaryDirectoryLocator()
        {
            throw new NotImplementedException();
            // Path.GetTempPath();
        }
    }
}
