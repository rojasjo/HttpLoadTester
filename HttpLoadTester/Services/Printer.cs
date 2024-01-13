namespace HttpLoadTester.Services;

public class Printer : IPrinter
{
    private static object consoleLock = new object();

    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintProgress(int completed, int total)
    {
        lock (consoleLock)
        {
            var percentage = completed * 100 / total;
            Console.CursorLeft = 0;
            Console.Write("Progress: {0}%", percentage);
        }
    }
}