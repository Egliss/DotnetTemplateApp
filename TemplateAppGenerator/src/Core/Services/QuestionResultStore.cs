using TemplateAppGenerator.Core.Schema;

namespace TemplateAppGenerator.Core.Services
{
    public interface IQuestionResultStore
    {
        public SharedQuestionResult shared { get; set; }
        public LinterQuestionResult lint { get; set; }
    }
    public class QuestionResultStore : IQuestionResultStore
    {
        public SharedQuestionResult shared { get; set; } = null;
        public LinterQuestionResult lint { get; set; } = null;
    }
}
