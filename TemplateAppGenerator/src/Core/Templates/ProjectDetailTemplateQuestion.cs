using FastEnumUtility;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace TemplateAppGenerator.Core.Template
{
    public enum ProjectType
    {
        Console,
        GUI
    }
    public enum ConsoleProjectFrameworkType
    {
        Default,
        GenericHost,
        ConsoleAppFramework,
        MagicOnionClient,
        ASP,
        MagicOnionServer,
    }
    public enum GUIProjectFramework
    {
        WPF,
        UWP,
        WinUI,
        MAUI,
    }

    public abstract class ProjectDetailTemplateQuestion
    {
        public static readonly string ProjectFrameworkQuestion = "Choose project base framework";
        public static readonly string ProjectTypeQuestion = "Choose project type";
        public static readonly string ProjectNameQuestion = "Project name";
    }
}
