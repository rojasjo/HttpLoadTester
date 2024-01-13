namespace HttpLoadTester.Models;

public class RequestStat
{
    public int Code { get; set; }
    
    public TimeSpan TimeToFirstByte { get; set; }
    
    public TimeSpan TimeToLastByte { get; set; }
    
    public DateTime Start { get; set; } = DateTime.Now;
    
    public DateTime End { get; set; } = DateTime.Now;
}