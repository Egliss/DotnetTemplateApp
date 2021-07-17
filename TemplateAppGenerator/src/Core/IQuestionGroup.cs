using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core
{
    public interface IQuestionGroup
    {
        public string name { get; }
        public int order { get; }
    }
}
