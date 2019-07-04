using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CountriesJson
{
    class CountriesJson
    {
        static void Main()
        {
            var countries = JsonConvert.DeserializeObject<List<Country>>(File.ReadAllText(@".\Data\americas.json"));

            var countryNameList = countries.Select(n => n.Name);
            Console.WriteLine("Список стран:");
            Console.WriteLine(string.Join(", ", countryNameList));
            Console.WriteLine();

            var sumPopulation = countries.Sum(n => n.Population);
            Console.WriteLine($"Общее население: {sumPopulation}");
            Console.WriteLine();

            var currencies = countries.SelectMany(n => n.Currencies).Select(n => n.Name).Distinct();

            Console.WriteLine("Список валют:");
            Console.WriteLine(string.Join(", ", currencies));

            Console.ReadLine();
        }
    }
}
