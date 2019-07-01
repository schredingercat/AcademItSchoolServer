using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Excel
{
    class Excel
    {
        static void Main()
        {
            var persons = new List<Person>
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

                sheet.Cells[1, 1].LoadFromText("First Name,Last Name,Age,Phone Number");
                var headerCellRange = sheet.Dimension.Address;

                sheet.Cells[headerCellRange].Style.Font.Bold = true;
                sheet.Cells[headerCellRange].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                sheet.Cells[headerCellRange].Style.Fill.PatternType = ExcelFillStyle.Solid;
                sheet.Cells[headerCellRange].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                var headerShift = sheet.Dimension.Rows + 1;

                for (int i = 0; i < persons.Count; i++)
                {
                    var person = persons[i];
                    var rowShift = i + headerShift;
                    sheet.Cells[rowShift, 1].Value = person.FirstName;
                    sheet.Cells[rowShift, 2].Value = person.LastName;
                    sheet.Cells[rowShift, 3].Value = person.Age;
                    sheet.Cells[rowShift, 4].Value = person.PhoneNumber;
                }

                var usedCellRange = sheet.Dimension.Address;

                sheet.Cells[usedCellRange].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                sheet.Cells[usedCellRange].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                sheet.Cells[usedCellRange].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Cells[usedCellRange].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                sheet.Cells[usedCellRange].AutoFitColumns();

                package.Save();
            }
        }
    }
}
