using System;

namespace LogOut
{
    class WriteToLog
    {
        static void Main()
        {
            Log.Debug("Hello");
            Log.Debug("World");
            Log.Debug("!");

            Log.Debug("Вывод исключения");
            try
            {
                var zero = 1 - 1;
                Console.WriteLine(1 / zero);
            }
            catch (Exception ex)
            {
                Log.Debug(ex);
            }

            Console.ReadLine();
        }

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
