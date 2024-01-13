using CommandLine;

namespace HttpLoadTester.Helpers;

public class CommandLineArgs
{
    [Option('u', "url", Required = true, HelpText = "URL to process.")]
    public string Url { get; set; }

    [Option('n', "number", Required = false, HelpText = "Number to process.")]
    public int Number { get; set; }
    
    [Option('c', "concurrency", Required = false, HelpText = "Number of concurrent process.")]
    public int Concurrency { get; set; }
    
    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}