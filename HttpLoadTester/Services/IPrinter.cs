namespace HttpLoadTester.Services;

public interface IPrinter
{
    void Print(string message);
    
    void PrintProgress(int completed, int total);
}