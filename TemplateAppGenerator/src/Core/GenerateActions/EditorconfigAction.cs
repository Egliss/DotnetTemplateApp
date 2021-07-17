using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateAppGenerator.Core.GenerateActions
{
    public class EditorconfigAction : IGenerateAction
    {
        public void Setup()
        {

        }

        public void Create(string editorConfigContent)
        {
            new FileActionHelper().CreateFile(".editorconfig", editorConfigContent);
        }
    }
}
