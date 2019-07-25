using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopEf.Models;

namespace ShopEf
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dB = new ShopContext())
            {
                Console.WriteLine(dB.Categories.Count());
            }

            Console.ReadLine();
        }
        
    }
}
