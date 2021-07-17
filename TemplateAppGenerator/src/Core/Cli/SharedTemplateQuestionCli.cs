using System;
using System.IO;
using TemplateAppGenerator.Core.Services;
using TemplateAppGenerator.Core.Template;

namespace TemplateAppGenerator.Core.Cli
{
    public class SharedTemplateQuestionCli : SharedTemplateQuestion, ICliQuestionGroup
    {
        public string name => nameof(SharedTemplateQuestionCli);
        public int order => -100;

        public void Question(IQuestionResultStore store, IConsoleInputProcessor console)
        {
            var isSimpleMode = console.WaitYesNoSelect(new SelectYesNoInputRequest
            {
                text = this.UseSimpleModeQuestion,
                defaultValue = true
            });
            string projectDirectory = string.Empty;
            do
            {
                projectDirectory = console.WaitInput<string>(new InputRequest<string>
                {
                    text = this.ProjectDirectoryQuestion,
                    defaultValue = Path.GetFullPath(Environment.CurrentDirectory),
                });

                // Edit will safe 
                if (Directory.Exists(projectDirectory) is false)
                    break;
                if (Directory.GetFiles(projectDirectory, "*").Length == 0)
                    break;
                // or user allow edit
            } while (InteractProjectExistFiles(console) is false);

            store.shared = new Schema.SharedQuestionResult(isSimpleMode: isSimpleMode, projectDirectory: projectDirectory);
        }

        private bool InteractProjectExistFiles(IConsoleInputProcessor processor)
        {
            var projectYesNoRequest = new SelectYesNoInputRequest()
            {
                defaultValue = true,
                text = this.AllowDangerousProjectDirectory
            };
            return processor.WaitYesNoSelect(projectYesNoRequest);
        }
    }
}
