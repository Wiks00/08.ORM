using System;
using System.Diagnostics;
using System.Linq;
using EFORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ORM.Tests
{
    [TestClass]
    public class Task2
    {
        [TestMethod]
        public void ListOfOrdersAndItProductsByCategory()
        {
            using (var db = new Northwind())
            {
                foreach (var category in db.Order_Details.Select(item => new { item.Product.Category.CategoryName, item.Order }).GroupBy(key => key.CategoryName, (categoryname, enumerable) => new
                {
                    Category = categoryname,
                    Orders = enumerable.Where(item => item.CategoryName == categoryname).Select(item => item.Order).ToList()
                }))
                {
                    Debug.WriteLine("Category: " + category.Category + " ------");

                    foreach (var order in category.Orders)
                    {
                        Debug.WriteLine("Order: " + order.OrderID + " ------");

                        foreach (var product in order.Order_Details.Select(item => item.Product).Where(item => item.Category.CategoryName == category.Category))
                        {
                            Debug.WriteLine("Product: " + product.ProductName);
                        }
                    }
                }
            }
        }
    }
}
