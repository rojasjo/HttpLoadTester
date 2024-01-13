namespace HttpLoadTester.Models;

public class Configuration
{
    public string Url { get; set; } = string.Empty;
    
    public int Number { get; set; } = 1;

    public int Concurrency { get; set; }
    
    public bool Verbose { get; set; }
}