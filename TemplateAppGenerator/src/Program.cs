using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using ZLogger;

using TemplateAppGenerator.Core;
using Microsoft.Extensions.Logging;
using ConsoleAppFramework;
using Microsoft.Extensions.DependencyInjection;
using TemplateAppGenerator.Core.Services;
using TemplateAppGenerator.Core.Cli;

namespace TemplateAppGenerator
{
    // EntryPoint
    static class Program
    {
        static async Task Main(string[] args)
        {
            await Host
                .CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostContext, configuration) =>
                {
                    var environment = hostContext.HostingEnvironment.EnvironmentName;
                    configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    // appsettings.{debug, release}.json
                    configuration.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging((context, builder) =>
                {
                    // Disable Console Logger
                    builder.ClearProviders();
#if DEBUG
                    builder.SetMinimumLevel(LogLevel.Debug);
#elif RELEASE
                    builder.SetMinimumLevel(LogLevel.Information);
#else
                    logging.SetMinimumLevel(LogLevel.Information);
#endif
                    builder.AddZLoggerRollingFile(
                        fileNameSelector: (dateTime, x) => $"logs/{dateTime.ToLocalTime():yyyy-MM-dd}_{x:000}.log",
                        timestampPattern: (dateTime) => dateTime.ToLocalTime().Date,
                        rollSizeKB: 4096
                    );
                })
                .ConfigureServices((context, service) =>
                {
                    service.AddSingleton<IQuestionResultStore, QuestionResultStore>();
                    service.AddSingleton<IConsoleInputProcessor, SharomptInputProcessor>();
                })
                .RunConsoleAppFrameworkAsync(args)
                .ConfigureAwait(false);
        }
    }
}
