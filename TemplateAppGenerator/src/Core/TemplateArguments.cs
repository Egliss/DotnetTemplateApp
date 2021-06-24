using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TemplateAppGenerator.Core
{
    public record TemplateArguments(
        IConsoleInputProcessor processor,
        IProjectTemplateContentStore store,
        CancellationToken token,
        int hierarchy = 0
        )
    {
    }
}
