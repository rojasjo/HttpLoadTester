using HttpLoadTester.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HttpLoadTester.Helpers;

public static class DependenciesHelper
{
    private static readonly ServiceProvider ServiceProvider;

    static DependenciesHelper()
    {
        ServiceProvider = new ServiceCollection()
            .AddScoped<IHttpClientWrapper, HttpClientWrapper>()
            .AddScoped<IPrinter, Printer>()
            .AddScoped<ILoadTester, LoadTester>()
            .AddScoped<IReportService, ReportService>()
            .BuildServiceProvider();
    }

    public static ILoadTester GetLoadTester()
    {
        var loadTester = ServiceProvider.GetService<ILoadTester>();

        if (loadTester == null)
        {
            throw new Exception("Could not get ILoadTester from DI container.");
        }

        return loadTester;
    }

    public static IPrinter GetPrinter()
    {
        var printer = ServiceProvider.GetService<IPrinter>();

        if (printer == null)
        {
            throw new Exception("Could not get ILoadTester from DI container.");
        }

        return printer;
    }
}