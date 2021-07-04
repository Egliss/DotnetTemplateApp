using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core
{
    public interface IProjectGenerator
    {
        public void NestInteractTo<T>(in TemplateArguments parentArgument) where T : class, IProjectTemplateContent, new();
        public void NestGenerateTo<T>(in TemplateArguments parentArgument) where T : class, IProjectTemplateContent, new();
    }
}
