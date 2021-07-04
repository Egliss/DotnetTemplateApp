using System;
using System.IO;

namespace TemplateAppGenerator.Core.Template
{
    public sealed class SharedTemplate : IProjectTemplateContent
    {
        public string name => "Shared";

        public bool isSimpleMode { get; private set; }
        public string projectDirectory { get; private set; }

        public void InteractUser(in TemplateArguments arg)
        {
            (var generator, var processor, var store, var token, var hierarchy) = arg;
            var blank = new string(' ', hierarchy * 2);

            this.isSimpleMode = processor.WaitInput<bool>(new InputRequest<bool>
            {
                text = $"{blank}use simple mode",
                defaultValue = true
            });
            this.projectDirectory = processor.WaitInput<string>(new InputRequest<string>
            {
                text = $"{blank}project generate directory",
                defaultValue = Path.GetFullPath(Environment.CurrentDirectory),
            });
            generator.NestInteractTo<ProjectTypeTemplate>(arg);
            generator.NestInteractTo<LinterTemplate>(arg);
        }


        public void Generate(in TemplateArguments argument)
        {
            throw new NotImplementedException();
        }
    }
}
