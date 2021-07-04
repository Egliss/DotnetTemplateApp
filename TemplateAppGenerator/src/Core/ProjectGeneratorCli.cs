using System;
using System.Threading;
using TemplateAppGenerator.Core.Template;

namespace TemplateAppGenerator.Core
{
    public class ProjectGeneratorCli : IProjectGenerator
    {
        private readonly IConsoleInputProcessor consoleProcessor = null;
        private readonly IProjectTemplateContentStore store = null;
        private IProjectTemplateContent activeContent = null;

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
            var argument = new TemplateArguments(this, this.consoleProcessor, this.store, token);
            this.NestInteractTo<SharedTemplate>(argument);
        }

        private void GenerateProject(CancellationToken token)
        {

        }

        public void NestInteractTo<T>(in TemplateArguments parentArgument) where T : class, IProjectTemplateContent, new()
        {
            var content = parentArgument.store.QueryContent<T>();
            Console.WriteLine(parentArgument.HierarchyBlank + $"[{content.name}]");
            var argument = parentArgument with { hierarchy = parentArgument.hierarchy + 1 };
            content.InteractUser(argument);
        }

        public void NestGenerateTo<T>(in TemplateArguments parentArgument) where T : class, IProjectTemplateContent, new()
        {
            var content = parentArgument.store.QueryContent<T>();
            Console.WriteLine(parentArgument.HierarchyBlank + $"[{content.name}]");
            var argument = parentArgument with { hierarchy = parentArgument.hierarchy + 1 };
            content.Generate(argument);
        }
    }
}
