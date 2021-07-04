namespace TemplateAppGenerator.Core
{
    public interface IProjectTemplateContent
    {
        public string name { get; }

        public void InteractUser(in TemplateArguments argument);
        public void Generate(in TemplateArguments argument);
    }
}
