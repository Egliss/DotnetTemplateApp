using System;
using System.Collections.Generic;
using System.Text;
using TemplateAppGenerator.Core;

namespace TemplateAppGenerator.Core.Template
{
    /// <summary>
    /// LinterTemplate provide .editorconfig and dotnet format(dotnet tool) installation.
    /// </summary>
    public sealed class LinterTemplate : IProjectTemplateContent
    {
        public string name => "Lint";

        public bool useEditorConfig { get; private set; } = false;
        public bool useDotnetFormat { get; private set; } = false;

        public void Generate(in TemplateArguments argument)
        {
            throw new NotImplementedException();
        }

        public void InteractUser(in TemplateArguments arg)
        {
            var simpleMode = arg.store.QueryContent<SharedTemplate>().isSimpleMode;

            if (simpleMode is true)
            {
                this.useEditorConfig = true;
                this.useDotnetFormat = true;
                return;
            }

            this.useEditorConfig = arg.processor.WaitYesNoSelect(new SelectYesNoInputRequest
            {
                text = $"{arg.HierarchyBlank}use .editorconfig",
                defaultValue = true
            });
            if (this.useEditorConfig is false)
                return;

            this.useDotnetFormat = arg.processor.WaitYesNoSelect(new SelectYesNoInputRequest
            {
                text = $"{arg.HierarchyBlank}use dotnet-format(https://github.com/dotnet/format)",
                defaultValue = true
            });
        }
    }
}
