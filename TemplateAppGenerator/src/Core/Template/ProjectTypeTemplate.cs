using FastEnumUtility;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core.Template
{

    public enum ProjectType
    {
        Console,
        ASP,
    }

    public sealed class ProjectTypeTemplate : IProjectTemplateContent
    {
        public string name => "project-type";

        public ProjectType type { get; private set; } = ProjectType.Console;

        public void InteractUser(in TemplateArguments argument)
        {
            var console = argument.processor;
            var blank = new string(' ', argument.hierarchy * 2);
            this.type = console.WaitSelectInput(new SelectInputRequest<ProjectType>()
            {
                items = FastEnum.GetValues<ProjectType>(),
                defaultValue = ProjectType.Console,
                text = $"{blank}choose project type"
            });

            this.Dispatch(argument);
        }

        private void Dispatch(in TemplateArguments argument)
        {
            var arg = argument with { hierarchy = argument.hierarchy + 1 };
            switch (this.type)
            {
                case ProjectType.Console:
                    break;
                case ProjectType.ASP:
                    break;
                default:
                    break;
            }
        }

        public void Generate(in TemplateArguments argument)
        {

        }
    }
}
