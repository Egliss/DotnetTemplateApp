using TemplateAppGenerator.Core.Schema;
using TemplateAppGenerator.Core.Services;

namespace TemplateAppGenerator.Core.Cli
{
    public class LinterTemplateQuestionCli : LinterTemplateQuestion, ICliQuestionGroup
    {
        public string name => nameof(LinterTemplateQuestionCli);
        public int order => 100;

        public void Question(IQuestionResultStore store, IConsoleInputProcessor console)
        {
            var simpleMode = store.shared.isSimpleMode;
            if (simpleMode is true)
            {
                store.lint = new LinterQuestionResult(useEditorConfig: true, useDotnetFormat: true);
                return;
            }

            var useEditorConfig = console.WaitYesNoSelect(new SelectYesNoInputRequest
            {
                text = $"{this.UseEditorConfigQuestion}",
                defaultValue = true
            });
            if (useEditorConfig is false)
            {
                store.lint = new LinterQuestionResult(useEditorConfig: false, useDotnetFormat: false);
                return;
            }

            var useDotnetFormat = console.WaitYesNoSelect(new SelectYesNoInputRequest
            {
                text = $"{UseEditorDotnetFormatuestion}",
                defaultValue = true
            });

            store.lint = new LinterQuestionResult(useEditorConfig: false, useDotnetFormat: useDotnetFormat);
        }
    }
}
