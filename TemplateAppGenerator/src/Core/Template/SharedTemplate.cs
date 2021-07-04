using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace TemplateAppGenerator.Core.Template
{
    public sealed class SharedTemplate : IProjectTemplateContent
    {
        public string name => "shared";

        public bool isSimpleMode { get; private set; }
        public string projectDirectory { get; private set; }
        public string projectName { get; private set; }

        public void InteractUser(in TemplateArguments argument)
        {
            (var processor, var store, var token, var hierarchy) = argument;
            var blank = new string(' ', hierarchy * 2);

            this.isSimpleMode = processor.WaitInput<bool>(new InputRequest<bool>
            {
                text = $"{blank}use simple mode",
                defaultValue = true
            });
            this.projectDirectory = processor.WaitInput<string>(new InputRequest<string>
            {
                text = $"{blank}project generate directory",
                defaultValue = Path.GetFullPath(Environment.CurrentDirectory),
            });
            this.projectName = processor.WaitInput<string>(new InputRequest<string>
            {
                text = $"{blank}project name",
                defaultValue = "NewProject1",
                validator = ValidateProjectName
            });

            this.InteractProjectEnvironment(argument);
        }
        public void InteractProjectEnvironment(in TemplateArguments argument)
        {
            var projectType = argument.store.QueryContent<ProjectTypeTemplate>();
            var linter = argument.store.QueryContent<LinterTemplate>();
            var arg = argument with { hierarchy = argument.hierarchy + 1 };

            linter.InteractUser(arg);
            projectType.InteractUser(arg);
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

        public void Generate(in TemplateArguments argument)
        {
            throw new NotImplementedException();
        }
    }
}
