using Cysharp.Diagnostics;
using System.IO;

namespace TemplateAppGenerator.Core.GenerateActions
{
    public class DotnetLocalToolAction : IGenerateAction
    {
        public static string FilePath = ".config/dotnet-tools.json";
        public static string FileGenerateCommand = "dotnet new tool-manifest";
        public static string AddLocalToolCommand = "dotnet tool install ";

        public void Setup()
        {
            ProcessX.StartAsync(FileGenerateCommand);
        }

        public void AddLocalTool(string libraryName, string? version = null)
        {
            var versionArgument = version is null ? string.Empty : $"--version {version}";
            var command = $"{AddLocalToolCommand} {libraryName} {versionArgument}";
            ProcessX.StartAsync(command);
        }

        public void Clean()
        {
            File.Delete(FilePath);
            var directory = Path.GetDirectoryName(FilePath);

            if (Directory.GetFiles(directory).Length == 0)
                Directory.Delete(directory);
        }
    }
}
