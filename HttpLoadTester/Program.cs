using CommandLine;
using HttpLoadTester.Helpers;
using HttpLoadTester.Models;

namespace HttpLoadTester;

public class Program
{
    public static async Task Main(string[] args)
    {
        await Parser.Default.ParseArguments<CommandLineArgs>(args)
            .WithParsedAsync(options =>
            {
                var printer = DependenciesHelper.GetPrinter();
                printer.Print("Starting load tests");
                
                var loadTester = DependenciesHelper.GetLoadTester();
                
                var configuration = new Configuration
                {
                    Url = options.Url,
                    Number = options.Number,
                    Concurrency = options.Concurrency,
                    Verbose = options.Verbose
                };
                
                return loadTester.Test(configuration);
            });
    }
}