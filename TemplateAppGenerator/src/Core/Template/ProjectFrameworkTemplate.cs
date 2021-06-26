using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core.Template
{
    public enum ProjectFrameworkType
    {
        GenericHost,
        ConsoleAppFramework,
        MagicOnion,
    }

    public class ProjectFrameworkTemplate : IProjectTemplateContent
    {
        public string name => "project construction";

        public ProjectFrameworkType framrwork { get; private set;  }

        public void InteractUser(in TemplateArguments argument)
        {
            this.framrwork = argument.processor.WaitInput(new InputRequest<ProjectFrameworkType>()
            {
                text = "choose project base framework",
                defaultValue = ProjectFrameworkType.GenericHost,
                usePasswordMode = false,
            });
        }

        public void Generate(in TemplateArguments argument)
        {
            

        }
    }
}
