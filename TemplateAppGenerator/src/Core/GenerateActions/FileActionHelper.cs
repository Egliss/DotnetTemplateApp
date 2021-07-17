using System.IO;

namespace TemplateAppGenerator.Core.GenerateActions
{
    public class FileActionHelper
    {
        public void CreateFile(string filePath, string fileContent)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, fileContent);
        }

        public void Clean(string filePath)
        {
            File.Delete(filePath);
            var directory = Path.GetDirectoryName(filePath);

            if (Directory.GetFiles(directory).Length is 0)
                Directory.Delete(directory);
        }
    }
}
