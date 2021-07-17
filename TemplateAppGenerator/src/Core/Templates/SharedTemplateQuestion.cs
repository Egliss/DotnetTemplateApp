namespace TemplateAppGenerator.Core.Template
{
    public abstract class SharedTemplateQuestion
    {
        public readonly string UseSimpleModeQuestion = "Use simple mode (simple mode omits some questions)";
        public readonly string ProjectDirectoryQuestion = "Project generate directory";
        public readonly string AllowDangerousProjectDirectory = "There are already some files in the directory. Do you want to continue?";
    }
}
