using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core.Schema
{
    public abstract class LinterTemplateQuestion
    {
        public readonly string UseEditorConfigQuestion = "Uuse .editorconfig";
        public readonly string UseEditorDotnetFormatuestion = "Use dotnet-format(https://github.com/dotnet/format)";
    }
}
