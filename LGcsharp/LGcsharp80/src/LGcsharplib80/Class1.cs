using System.Diagnostics;
using LGcsharplib80.LGcommons;

namespace LGcsharplib80
{
    public class LGsharplib80Class1
    {
        public static void funcTest(string fmt, params object[] args)
        {
            
            Console.WriteLine(fmt);
            Console.WriteLine(args);
            Console.WriteLine(fmt, args);
        }
    }
}