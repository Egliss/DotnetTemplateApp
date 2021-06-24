using System;
using TemplateAppGenerator.Core;

namespace TemplateAppGenerator
{
    static class Program
    {
        static void Main(string[] args)
        {
            ValidateArgument(args);
            ProjectGeneratorCli cli = new ProjectGeneratorCli();
            cli.Run();
        }

        private static void ValidateArgument(in string[] args)
        {
            if (args.Length > 0)
            {
            }
        }
    }
}
