﻿using System;
using System.Collections.Generic;
using System.Linq;
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

                var intelCoreI7 = new Product { Name = "Intel Core i7", Categories = new List<Category> { cpuCategory, componentsCategory }, Price = 22999 };
                var corsairRam = new Product { Name = "Corsair XMS3", Categories = new List<Category> { ramCategory, componentsCategory }, Price = 1999 };
                var logitechMouse = new Product { Name = "Logitech M90", Categories = new List<Category> { mouseCategory, hidCategory }, Price = 450 };
                var microsoftKeyboard = new Product { Name = "Microsoft Wired Keyboard 600", Categories = new List<Category> { keyboardCategory, hidCategory }, Price = 999 };

                dataBase.Products.Add(intelCoreI7);
                dataBase.Products.Add(corsairRam);
                dataBase.Products.Add(logitechMouse);
                dataBase.Products.Add(microsoftKeyboard);

                var ivanovCustomer = new Customer { Name = "Иванов Иван Иванович", PhoneNumber = "+7 999 123-456", Email = "ivanov@email.com" };
                var petrovCustomer = new Customer { Name = "Петров Петр Петрович", PhoneNumber = "+7 988 456-123", Email = "petrov@email.com" };
                var nikolaevCustomer = new Customer { Name = "Николаев Николай Николаевич", PhoneNumber = "+7 931 415-926", Email = "nikolaev@email.com" };

                dataBase.Customers.Add(ivanovCustomer);
                dataBase.Customers.Add(petrovCustomer);
                dataBase.Customers.Add(nikolaevCustomer);

                dataBase.Orders.Add(new Order
                {
                    Customer = ivanovCustomer,
                    Date = new DateTime(2019, 06, 12),
                    Products = new List<Product> { intelCoreI7 }
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

                var targetCustomers = dataBase.Customers.Where(n => n.Name.Contains("Николаевич"));
                Console.WriteLine($"Найдено Николаевичей: {targetCustomers.Count()}");
                Console.WriteLine();

                foreach (var customer in targetCustomers)
                {
                    customer.Name = customer.Name.Replace("Николаевич", "Сергеевич");
                }
                dataBase.SaveChanges();

                var mostSoldProduct = dataBase.Orders
                    .SelectMany(x => x.Products)
                    .GroupBy(n => n)
                    .OrderByDescending(n => n.Count())
                    .FirstOrDefault();

                Console.WriteLine($"Самый продаваемый товар: {mostSoldProduct?.Key.Name} ({mostSoldProduct?.Count()} шт.)");
                Console.WriteLine();

                var moneyByCustomer = dataBase.Orders.GroupBy(n => n.Customer)
                    .Select(g => new
                    {
                        CustomerName = g.Select(n => n.Customer.Name).FirstOrDefault(),
                        Total = g.Sum(s => s.Products.Select(t => t.Price).Sum())
                    })
                    .ToList()
                    .Select(x => $"{x.CustomerName} - {x.Total.ToString()} руб.");

                Console.WriteLine("Сумма, потраченная каждым клиентом:");
                Console.WriteLine(string.Join("\n", moneyByCustomer));
                Console.WriteLine();

                var countByCategory = dataBase.Orders
                    .SelectMany(o => o.Products)
                    .SelectMany(p => p.Categories)
                    .GroupBy(n => n).OrderByDescending(n => n.Count()).ToList();

                Console.WriteLine("Продано товаров каждой категории:");
                Console.WriteLine(string.Join("\n", countByCategory.Select(n => $"{n.Key.Name} - {n.Count()} шт.")));
            }

            Console.ReadLine();
        }
    }
}
