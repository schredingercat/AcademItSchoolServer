using System;

namespace TextFromDll
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(HelloWorld.HelloWorld.HelloWorldText);
            Console.ReadLine();
        }
    }
}
