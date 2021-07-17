using ConsoleAppFramework;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using TemplateAppGenerator.Core.Cli;
using TemplateAppGenerator.Core.GenerateActions;
using TemplateAppGenerator.Core.Services;
using TemplateAppGenerator.Core.Template;

namespace TemplateAppGenerator.Core
{
    public class ProjectGeneratorCli : ConsoleAppBase, IProjectGenerator
    {
        private readonly IConsoleInputProcessor console = null;
        private readonly IGenerateActionStore actionStore = null;
        private readonly IQuestionResultStore resultStore = null;

        public ProjectGeneratorCli(IQuestionResultStore resultStore, IConsoleInputProcessor console = null, IGenerateActionStore actionStore = null)
        {
            this.console = console ?? new SharomptInputProcessor();
            this.actionStore = actionStore ?? new GenerateActionStore();
            this.resultStore = resultStore ?? new QuestionResultStore();
        }

        public void Run(CancellationToken token = default(CancellationToken))
        {
            this.InjectActions();
            this.InteractUser(token);
            this.GenerateProject(token);
        }

        private void InteractUser(CancellationToken token)
        {
            var questions = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(m => m.IsSubclassOf(typeof(ICliQuestionGroup)))
                .Select(m => m.GetConstructor(Type.EmptyTypes).Invoke(null))
                .Cast<ICliQuestionGroup>()
                .OrderBy(m => m.order)
                .ToArray();

            foreach (var item in questions)
            {
                item.Question(this.resultStore, this.console);
            }
        }

        private void GenerateProject(CancellationToken token)
        {

        }

        public void InjectActions()
        {
            this.actionStore.QueryContent<DotnetLocalToolAction>();
            this.actionStore.QueryContent<EditorconfigAction>();
        }
    }
}
