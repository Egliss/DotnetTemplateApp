using System.IO;

namespace TemplateAppGenerator.Core.FileActions
{
    public class DotnetLocalToolActions
    {
        public static string FilePath = ".config/dotnet-tools.json";

        public void Setup()
        {
            var directory = Path.GetDirectoryName(FilePath);
            Directory.CreateDirectory(directory);

            // generate empty json
            File.WriteAllText(FilePath, "{}");
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
