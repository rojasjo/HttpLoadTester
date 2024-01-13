using HttpLoadTester.Models;

namespace HttpLoadTester;

public interface ILoadTester
{
    Task Test(Configuration configuration);
}