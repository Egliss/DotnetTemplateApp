using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core
{
    // Template
    public interface ITemplateLocator
    {
        public string location { get; }
        public string GetRaw();

        // To temporary file locator
        public ITemplateLocator ToTemporaryDirectoryLocator();
    }
}
