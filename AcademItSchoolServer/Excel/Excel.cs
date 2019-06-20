using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;

namespace Excel
{
    class Excel
    {
        static void Main()
        {
            var persons = new List<Person>()
            {
                new Person("Ivan", "Petrov", 20, "+7 (901) 111-2222"),
                new Person("Petr", "Ivanov", 31, "+7 (902) 222-3333"),
                new Person("Nikolay", "Nikolaev", 42, "+7 (903) 333-4444"),
                new Person("John", "Smith", 53, "+1 (555) 999-8888"),
            };

            var fileName = "PersonsBook.xlsx";
            SavePersonsToExcelFile(persons, fileName);

            Process.Start(fileName);
        }

        public static void SavePersonsToExcelFile(List<Person> persons, string path)
        {
            File.Delete(path);
            var fileInfo = new FileInfo(path);

            using (var package = new ExcelPackage(fileInfo))
            {
                var sheet = package.Workbook.Worksheets.Add("Persons");

                for (int i = 1; i <= persons.Count; i++)
                {
                    var person = persons[i - 1];
                    sheet.Cells[i, 1].Value = person.FirstName;
                    sheet.Cells[i, 2].Value = person.LastName;
                    sheet.Cells[i, 3].Value = person.Age;
                    sheet.Cells[i, 4].Value = person.PhoneNumber;
                }
                package.Save();
            }
        }

        public class Person
        {
            public string FirstName;
            public string LastName;
            public int Age;
            public string PhoneNumber;

            public Person(string firstName, string lastName, int age, string phoneNumber)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                PhoneNumber = phoneNumber;
            }
        }
    }
}
