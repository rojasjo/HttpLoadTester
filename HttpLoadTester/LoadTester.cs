using System.Collections.Concurrent;
using HttpLoadTester.Models;
using HttpLoadTester.Services;

namespace HttpLoadTester;

public class LoadTester : ILoadTester
{
    private readonly IHttpClientWrapper _httpClientWrapper;
    private readonly IPrinter _printer;
    private readonly IReportService _reportService;

    private readonly ConcurrentQueue<RequestStat> _results = new();

    private int _completed;
    private Configuration _configuration;

    public LoadTester(IHttpClientWrapper httpClientWrapper, IPrinter printer, IReportService reportService)
    {
        _httpClientWrapper = httpClientWrapper;
        _printer = printer;
        _reportService = reportService;
    }

    public async Task Test(Configuration configuration)
    {
        _results.Clear();
        _completed = 0;
        _configuration = configuration;

        if (configuration.Concurrency == 0)
        {
            await SequentialRequests(configuration.Url, configuration.Number);
        }
        else
        {
            await ParallelRequests(configuration.Url, configuration.Number, configuration.Concurrency);
        }

        _reportService.PrintReport(_results.ToList());
    }

    private async Task ParallelRequests(string url, int requests, int concurrency)
    {
        var groups = (int)Math.Ceiling(requests / (float)concurrency);

        for (var i = 0; i < groups; i++)
        {
            var tasks = new List<Task>(concurrency);

            for (var j = 0; j < concurrency; j++)
            {
                _completed++;

                if (_completed > requests)
                {
                    break;
                }

                tasks.Add(SingleRequest(url));
            }

            await Task.WhenAll(tasks);
        }
    }

    private async Task SequentialRequests(string url, int requests)
    {
        for (var i = 0; i < requests; i++)
        {
            await SingleRequest(url);
            _completed++;
        }
    }

    private async Task SingleRequest(string url)
    {
        var response = await _httpClientWrapper.GetAsync(url);

        if (_configuration.Verbose)
        {
            _reportService.PrintLine(response);
        }
        else
        {
            _printer.PrintProgress(_completed, _configuration.Number);
        }

        _results.Enqueue(response);
    }
}