using Serilog;

namespace TestConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://116.62.145.219:5341")
                .CreateLogger();

            Log.Information("Hello Seq! This is a test log.");
            Log.Error("Something went wrong with {Test}", "SeqTest");

            Log.CloseAndFlush();
        }
    }
}
