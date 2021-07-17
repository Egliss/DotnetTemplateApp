using FastEnumUtility;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TemplateAppGenerator.Core.Services;
using TemplateAppGenerator.Core.Template;

namespace TemplateAppGenerator.Core.Cli
{
    public class ProjectDetailTemplateQuestionCli : ProjectDetailTemplateQuestion, ICliQuestionGroup
    {
        public string name { get; }
        public int order { get; }

        public void Question(IQuestionResultStore store, IConsoleInputProcessor console)
        {
            var projectName = console.WaitInput<string>(new InputRequest<string>
            {
                text = ProjectFrameworkQuestion,
                defaultValue = "NewProject1",
                validator = ValidateProjectName,
            });
            var type = console.WaitSelectInput(new SelectInputRequest<ProjectType>()
            {
                items = FastEnum.GetValues<ProjectType>(),
                defaultValue = ProjectType.Console,
                text = ProjectTypeQuestion,
            });
            var consoleFramework = console.WaitSelectInput(new SelectInputRequest<ConsoleProjectFrameworkType>()
            {
                items = FastEnum.GetValues<ConsoleProjectFrameworkType>(),
                text = ProjectFrameworkQuestion,
            });
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
