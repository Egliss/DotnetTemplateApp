using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core
{
    public class ProjectTemplateController
    {
    }

    public interface IProjectTemplateContent
    {
        public string name { get; }

        public void InteractUser(in TemplateArguments argument);
        public void Generate(in TemplateArguments argument);
    }
}
