using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TemplateAppGenerator.Core
{
    public record TemplateArguments(
        IProjectGenerator generator,
        IConsoleInputProcessor processor,
        IProjectTemplateContentStore store,
        CancellationToken token,
        int hierarchy = 0
        )
    {
        public string HierarchyBlank => new string(' ', hierarchy * 2);
    }
}
