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
        static void Main()
        {
            using (var dataBase = new ShopContext())
            {
                #region FillDataBase

                var cpuCategory = new Category { Name = "CPU" };
                var ramCategory = new Category { Name = "RAM" };
                var keyboardCategory = new Category { Name = "Keyboard" };
                var mouseCategory = new Category { Name = "Mouse" };
                var hidCategory = new Category { Name = "HID" };
                var componentsCategory = new Category { Name = "Components" };

                dataBase.Categories.Add(cpuCategory);
                dataBase.Categories.Add(ramCategory);
                dataBase.Categories.Add(keyboardCategory);
                dataBase.Categories.Add(mouseCategory);
                dataBase.Categories.Add(hidCategory);
                dataBase.Categories.Add(componentsCategory);

                var intelCoreI7 = new Product { Name = "Intel Core i3", Categories = new List<Category> { cpuCategory, componentsCategory }, Price = 22999 };
                var corsairRam = new Product { Name = "Corsair XMS3", Categories = new List<Category> { ramCategory, componentsCategory }, Price = 1999 };
                var logitechMouse = new Product { Name = "Logitech M90", Categories = new List<Category> { mouseCategory, hidCategory }, Price = 450 };
                var microsoftKeyboard = new Product { Name = "Microsoft Wired Keyboard 600", Categories = new List<Category> { keyboardCategory, hidCategory }, Price = 999 };

                dataBase.Products.Add(intelCoreI7);
                dataBase.Products.Add(corsairRam);
                dataBase.Products.Add(logitechMouse);
                dataBase.Products.Add(microsoftKeyboard);

                var ivanovCustomer = new Customer{Name = "Иванов Иван Иванович", PhoneNumber = "+7 999 123-456", Email = "ivanov@email.com"};
                var petrovCustomer = new Customer { Name = "Петров Петр Петрович", PhoneNumber = "+7 988 456-123", Email = "petrov@email.com" };
                var nikolaevCustomer = new Customer { Name = "Николаев Николай Николаевич", PhoneNumber = "+7 931 415-926", Email = "nikolaev@email.com" };

                dataBase.Customers.Add(ivanovCustomer);
                dataBase.Customers.Add(petrovCustomer);
                dataBase.Customers.Add(nikolaevCustomer);

                dataBase.Orders.Add(new Order
                {
                    Customer = ivanovCustomer,
                    Date = new DateTime(2019, 06, 12),
                    Products = new List<Product> {intelCoreI7}
                });

                dataBase.Orders.Add(new Order
                {
                    Customer = ivanovCustomer,
                    Date = new DateTime(2019, 06, 13),
                    Products = new List<Product> { intelCoreI7 }
                });

                dataBase.Orders.Add(new Order
                {
                    Customer = ivanovCustomer,
                    Date = new DateTime(2019, 06, 14),
                    Products = new List<Product> { intelCoreI7 }
                });

                dataBase.Orders.Add(new Order
                {
                    Customer = petrovCustomer,
                    Date = new DateTime(2019, 06, 14),
                    Products = new List<Product> { corsairRam, logitechMouse }
                });

                dataBase.Orders.Add(new Order
                {
                    Customer = nikolaevCustomer,
                    Date = new DateTime(2019, 06, 14),
                    Products = new List<Product> { corsairRam, logitechMouse, microsoftKeyboard }
                });

                dataBase.Orders.Add(new Order
                {
                    Customer = ivanovCustomer,
                    Date = new DateTime(2019, 06, 15),
                    Products = new List<Product> { intelCoreI7, corsairRam, logitechMouse, microsoftKeyboard }
                });

                dataBase.SaveChanges();

                #endregion

                
                Console.WriteLine(dataBase.Categories.Count());
                Console.WriteLine(string.Join(", ", dataBase.Products.FirstOrDefault().Categories.Select(n => n.Name)));
            }

            Console.ReadLine();
        }

    }
}
