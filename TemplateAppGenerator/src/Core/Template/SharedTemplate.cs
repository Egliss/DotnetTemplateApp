using System;
using System.IO;

namespace TemplateAppGenerator.Core.Template
{
    public sealed class SharedTemplate : IProjectTemplateContent
    {
        public string name => "Shared";

        public bool isSimpleMode { get; private set; }
        public string projectDirectory { get; private set; }

        public void InteractUser(in TemplateArguments arg)
        {
            (var generator, var processor, var store, var token, var hierarchy) = arg;
            var blank = new string(' ', hierarchy * 2);

            this.isSimpleMode = processor.WaitYesNoSelect(new SelectYesNoInputRequest
            {
                text = $"{blank}use simple mode",
                defaultValue = true
            });
            do
            {
                this.projectDirectory = processor.WaitInput<string>(new InputRequest<string>
                {
                    text = $"{blank}project generate directory",
                    defaultValue = Path.GetFullPath(Environment.CurrentDirectory),
                });

                // Edit will safe 
                if (Directory.Exists(this.projectDirectory) is false)
                    break;
                if (Directory.GetFiles(this.projectDirectory, "*").Length == 0)
                    break;
                // or user allow edit
            } while (InteractProjectExistFiles(arg.processor) is false);

            generator.NestInteractTo<ProjectTypeTemplate>(arg);
            generator.NestInteractTo<LinterTemplate>(arg);
        }

        private static bool InteractProjectExistFiles(IConsoleInputProcessor processor)
        {
            var projectYesNoRequest = new SelectYesNoInputRequest()
            {
                defaultValue = true,
                text = "There are already some files in the directory. Do you want to continue?"
            };
            return processor.WaitYesNoSelect(projectYesNoRequest);
        }

        public void Generate(in TemplateArguments argument)
        {
            throw new NotImplementedException();
        }
    }
}
