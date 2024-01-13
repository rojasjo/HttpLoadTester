using HttpLoadTester.Models;

namespace HttpLoadTester.Services;

public interface IReportService
{
    void PrintReport(IList<RequestStat> stats);

    void PrintLine(RequestStat stat);
}