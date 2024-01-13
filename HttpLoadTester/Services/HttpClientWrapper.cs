using System.Diagnostics;
using HttpLoadTester.Models;

namespace HttpLoadTester.Services;

public class HttpClientWrapper : IHttpClientWrapper
{
    private readonly HttpClient _httpClient = new();

    public async Task<RequestStat> GetAsync(string url)
    {
        var requestStat = new RequestStat()
        {
            Start = DateTime.Now
        };

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        try
        {
            var response = await _httpClient.GetAsync(url);

            stopwatch.Stop();
            requestStat.TimeToFirstByte = stopwatch.Elapsed;

            stopwatch.Restart();
            _ = response.Content.ReadAsStringAsync();

            stopwatch.Stop();
            requestStat.TimeToLastByte = stopwatch.Elapsed;

            requestStat.Code = (int)response.StatusCode;
        }
        catch
        {
            requestStat.Code = 500;
        }

        requestStat.End = DateTime.Now;
        return requestStat;
    }
}