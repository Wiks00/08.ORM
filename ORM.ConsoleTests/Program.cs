using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFORM;
using ORM.Models;

namespace ORM.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Northwind())
            {
                foreach(var category in db.Order_Details.Select(item => new {item.Product.Category.CategoryName, item.Order}).GroupBy(key => key.CategoryName, (categoryname, enumerable) => new
                {
                    Category = categoryname,
                    Orders = enumerable.Where(item => item.CategoryName == categoryname).Select(item => item.Order).ToList()
                }))
                {
                    Console.WriteLine("Category: " + category.Category + " ------");

                    foreach (var order in category.Orders)
                    {
                        Console.WriteLine("Order: " + order.OrderID + " ------");

                        foreach (var product in order.Order_Details.Select(item => item.Product).Where(item => item.Category.CategoryName == category.Category))
                        {
                            Console.WriteLine("Product: " + product.ProductName);
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
