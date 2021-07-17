using TemplateAppGenerator.Core.Services;

namespace TemplateAppGenerator.Core.Cli
{
    public interface ICliQuestionGroup : IQuestionGroup
    {
        public void Question(IQuestionResultStore store, IConsoleInputProcessor console);
    }
}
