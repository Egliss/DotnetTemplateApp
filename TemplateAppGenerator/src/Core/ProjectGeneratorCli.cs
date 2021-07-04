using System.Threading;
using TemplateAppGenerator.Core.Template;

namespace TemplateAppGenerator.Core
{
    public class ProjectGeneratorCli : IProjectGenerator
    {
        public ProjectGeneratorCli(IConsoleInputProcessor processor = null, IProjectTemplateContentStore store = null)
        {
            this.consoleProcessor = processor ?? new SharomptInputProcessor();
            this.store = store ?? new ProjectTemplateContentStore();
            this.activeContent = new SharedTemplate();
        }

        public void Run(CancellationToken token = default(CancellationToken))
        {
            this.InteractUser(token);
            this.GenerateProject(token);
        }

        private void InteractUser(CancellationToken token)
        {
            var argument = new TemplateArguments(this.consoleProcessor, this.store, token);
            var root = argument.store.QueryContent<SharedTemplate>();
            this.activeContent = root;
            this.activeContent.InteractUser(argument);
        }

        private void GenerateProject(CancellationToken token)
        {

        }

        private readonly IConsoleInputProcessor consoleProcessor = null;
        private readonly IProjectTemplateContentStore store = null;
        private IProjectTemplateContent activeContent = null;
    }
}
