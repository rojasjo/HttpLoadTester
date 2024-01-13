using HttpLoadTester.Models;

namespace HttpLoadTester.Services;

public interface IHttpClientWrapper
{
    Task<RequestStat> GetAsync(string url);
    
}