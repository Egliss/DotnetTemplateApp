using FastEnumUtility;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace TemplateAppGenerator.Core.Template
{
    public enum ProjectType
    {
        Console,
        GUI
    }
    public enum ConsoleProjectFrameworkType
    {
        Default,
        GenericHost,
        ConsoleAppFramework,
        MagicOnionClient,
        ASP,
        MagicOnionServer,
    }
    public enum GUIProjectFramework
    {
        WPF,
        UWP,
        WinUI,
        MAUI,
    }

    public sealed class ProjectTypeTemplate : IProjectTemplateContent
    {
        public string name => "Project";

        public string projectName { get; private set; }
        public ProjectType type { get; private set; } = ProjectType.Console;
        public ConsoleProjectFrameworkType consoleFramework { get; private set; }
        public GUIProjectFramework guiFramework { get; private set; }

        public void InteractUser(in TemplateArguments arg)
        {
            this.projectName = arg.processor.WaitInput<string>(new InputRequest<string>
            {
                text = $"{arg.HierarchyBlank}project name",
                defaultValue = "NewProject1",
                validator = ValidateProjectName
            });
            this.type = arg.processor.WaitSelectInput(new SelectInputRequest<ProjectType>()
            {
                items = FastEnum.GetValues<ProjectType>(),
                defaultValue = ProjectType.Console,
                text = $"{arg.HierarchyBlank}choose project type"
            });
            this.consoleFramework = arg.processor.WaitSelectInput(new SelectInputRequest<ConsoleProjectFrameworkType>()
            {
                items = FastEnum.GetValues<ConsoleProjectFrameworkType>(),
                text = $"{arg.HierarchyBlank}choose project base framework",
                defaultValue = ConsoleProjectFrameworkType.GenericHost,
            });
        }

        public void Generate(in TemplateArguments argument)
        {
            // TODO ASP.NET Requirement chack!
        }

        public static ValidationResult ValidateProjectName(object obj)
        {
            var name = obj.ToString();
            if (name.Length < 2)
            {
                return new ValidationResult("The length of the project name must be at least 1.");
            }
            if (Regex.IsMatch(name, "(\\\\|\\/|\\:|\\*|\\?|<|>|\\||\\\")"))
            {
                return new ValidationResult("Contains characters that cannot be used.");
            }
            if (name.Length != name.Trim().Length)
            {
                return new ValidationResult("It is not recommended to use spaces or control characters in the project name.");
            }

            return ValidationResult.Success;
        }

    }
}
