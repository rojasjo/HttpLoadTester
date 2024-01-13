using HttpLoadTester.Models;

namespace HttpLoadTester.Services;

public class ReportService : IReportService
{
    private readonly IPrinter _printer;

    public ReportService(IPrinter printer)
    {
        _printer = printer;
    }

    public void PrintReport(IList<RequestStat> stats)
    {
        var successes = stats.Count(x => x.Code is >= 200 and < 300);
        var failures = stats.Count(x => x.Code is >= 500 and < 600);

        _printer.Print($"{Environment.NewLine}Results:");
        _printer.Print($"  Total Requests (2XX).......................: {successes}");
        _printer.Print($"  Failed Requests (5XX)......................: {failures}");

        var first = stats.Min(p => p.Start);
        var last = stats.Max(p => p.End);
        var totalTime = last.Subtract(first).TotalSeconds;
        _printer.Print($"  Total Time (s)..............................: {totalTime}");
        _printer.Print($"  Request/second.............................: {stats.Count / totalTime}");

        var times = stats.Select(x => x.TimeToFirstByte.TotalSeconds + x.TimeToLastByte.TotalSeconds)
            .ToList();
        _printer.Print(
            $"Total Request Time (s) (Min, Max, Mean).....: {times.Min()}, {times.Max()}, {times.Average()}");

        var timesToFirstByte = stats.Select(x => x.TimeToFirstByte.TotalSeconds).ToList();
        _printer.Print(
            $"Time to first byte (s) (Min, Max, Mean)....................: {timesToFirstByte.Min()}, {timesToFirstByte.Max()}, {timesToFirstByte.Average()}");

        var timesToLastByte = stats.Select(x => x.TimeToLastByte.TotalSeconds).ToList();
        _printer.Print(
            $"Time to last byte (s) (Min, Max, Mean).....................: {timesToLastByte.Min()}, {timesToLastByte.Max()}, {timesToLastByte.Average()}");
    }

    public void PrintLine(RequestStat stat)
    {
        _printer.Print($"Code:  {stat.Code}, TTFB: {stat.TimeToFirstByte.TotalMilliseconds}, TTLB: {stat.TimeToLastByte.TotalMilliseconds} ms, Total: {(stat.End - stat.Start).TotalMilliseconds} ms");
    }
}