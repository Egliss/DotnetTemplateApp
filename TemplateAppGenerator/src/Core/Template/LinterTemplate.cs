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
        public string name => "linter";

        public bool useEditorConfig { get; private set; } = false;
        public bool useDotnetFormat { get; private set; } = false;

        public void Generate(in TemplateArguments argument)
        {
            throw new NotImplementedException();
        }

        public void InteractUser(in TemplateArguments argument)
        {
            (var processor, var store, var token, var hierarchy) = argument;
            var blank = new string(' ', hierarchy * 2);
            var simpleMode = argument.store.QueryContent<SharedTemplate>().isSimpleMode;

            if (simpleMode is true)
            {
                this.useEditorConfig = true;
                this.useDotnetFormat = true;
                return;
            }

            this.useEditorConfig = processor.WaitInput<bool>(new InputRequest<bool>
            {
                text = $"{blank}use .editorconfig",
                defaultValue = true
            });
            if (this.useEditorConfig is false)
                return;

            this.useDotnetFormat = processor.WaitInput<bool>(new InputRequest<bool>
            {
                text = $"{blank}use dotnet-format(https://github.com/dotnet/format)",
                defaultValue = true
            });
        }
    }
}
