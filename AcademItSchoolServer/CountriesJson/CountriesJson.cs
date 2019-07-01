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

            var countryNameList = countries.Select(n => n.name);
            Console.WriteLine("Список стран:");
            Console.WriteLine(string.Join(", ", countryNameList));
            Console.WriteLine();

            var sumPopulation = countries.Sum(n => n.population);
            Console.WriteLine($"Общее население: {sumPopulation}");
            Console.WriteLine();

            var currencies = countries.SelectMany(n => n.currencies).Select(n => n.name).Distinct();

            Console.WriteLine("Список валют:");
            Console.WriteLine(string.Join(", ", currencies));

            Console.ReadLine();
        }
    }
}
