using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core.Schema
{
    public record LinterQuestionResult(bool useEditorConfig, bool useDotnetFormat)
    {
    }
}
