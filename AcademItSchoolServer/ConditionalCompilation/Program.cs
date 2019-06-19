using System;

namespace ConditionalCompilation
{
    class Program
    {
        static void Main()
        {
            #region ConditionalCompilationRegion
#if (DEBUG)
            Console.WriteLine("Debug");
#else
            Console.WriteLine("Release");
#endif
            #endregion

            Console.ReadLine();
        }
    }
}
