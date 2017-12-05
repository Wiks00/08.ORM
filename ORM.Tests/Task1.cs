using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM;
using ORM.Models;

namespace ORM.Tests
{
    [TestClass]
    public class Task1
    {
        [TestMethod]
        public void ListOfProductsWithCategoriesAndSuppliers()
        {
            using (var db = new NorthwindDB("Northwind"))
            {
                foreach (var product in db.Products.LoadWith(t => t.Supplier).LoadWith(t => t.Category))
                {
                    Debug.WriteLine($"---------------\n{product.ProductName}\n{product.Category?.CategoryName}\n{product.Supplier?.CompanyName}");
                }
            }
        }

        [TestMethod]
        public void ListOfEmployeesWithTerritories()
        {
            using (var db = new NorthwindDB("Northwind"))
            {


                foreach (var employee in db.Employees
                    .Join(db.EmployeeTerritories
                            .Join(db.Territories.LoadWith(t => t.Region),
                                empTerritories => empTerritories.TerritoryID,
                                territories => territories.TerritoryID,
                                (empTerritories, territories) => new
                                {
                                    empTerritories.EmployeeID,
                                    territories.Region.RegionDescription
                                }),
                        employees => employees.EmployeeID,
                        _ => _.EmployeeID,
                        (employees, _) => new
                        {
                            employees.FirstName,
                            Region = _.RegionDescription
                        })
                            .GroupBy(key => key.FirstName,
                            (s, enumerable) => new
                            {
                                FirstName = s,
                                Regions = enumerable.Where(item => item.FirstName == s).ToList().Select(item => item.Region)
                            }))
                {
                    Debug.WriteLine($"---------------\n{employee.FirstName}");

                    foreach (var region in employee.Regions)
                    {
                        Debug.WriteLine($"{region}");
                    }
                }
            }
        }

        [TestMethod]
        public void RegionStatistics()
        {
            using (var db = new NorthwindDB("Northwind"))
            {
                foreach (var region in db.Employees
                    .Join(db.EmployeeTerritories
                            .Join(db.Territories.LoadWith(t => t.Region),
                                empTerritories => empTerritories.TerritoryID,
                                territories => territories.TerritoryID,
                                (empTerritories, territories) => new
                                {
                                    empTerritories.EmployeeID,
                                    territories.Region.RegionDescription
                                }),
                        employees => employees.EmployeeID,
                        _ => _.EmployeeID,
                        (employees, _) => new
                        {
                            employees.FirstName,
                            Region = _.RegionDescription
                        })
                            .GroupBy(key => key.Region,
                            (s, enumerable) => new
                            {
                                Region = s,
                                Count = enumerable.Count(item => item.Region == s)
                            }))
                {
                    Debug.WriteLine($"---------------\n{region.Region}");

                    Debug.WriteLine($"{region.Count}");
                }
            }
        }

        [TestMethod]
        public void EmployeesShippers()
        {
            using (var db = new NorthwindDB("Northwind"))
            {
                LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;

                foreach (var employee in db.Orders
                    .LoadWith(t => t.Employee)
                    .LoadWith(t => t.Shipper)
                    .Select(item => new {item.Employee.FirstName, item.Shipper.CompanyName})
                    .GroupBy(key => key.FirstName, (s, enumerable) => new
                    {
                        FirstName = s,
                        Shippers = enumerable.Where(item => item.FirstName == s).Select(item => item.CompanyName).Distinct().ToList()
                    })
                )
                   
                {
                    Debug.WriteLine($"---------------\n{employee.FirstName}");

                    foreach (var shipper in employee.Shippers)
                    {
                        Debug.WriteLine($"{shipper}");
                    }
                }
            }
        }

        [TestMethod]
        public void InsertNewEmployee()
        {
            using (var db = new NorthwindDB("Northwind"))
            {
                var empId = Convert.ToInt32(db.InsertWithIdentity(new Employees {FirstName = "Ilya", LastName = "Lipai"}));

                db.EmployeeTerritories
                    .Value(et => et.EmployeeID, empId)
                    .Value(et => et.TerritoryID, "10019")
                    .Insert();
            }
        }

        [TestMethod]
        public void UpdateProductsCategory()
        {
            using (var db = new NorthwindDB("Northwind"))
            {
                db.Products
                  .Where(p => p.CategoryID == 7)
                  .Set(p => p.CategoryID, 6)
                  .Update();
            }
        }

        [TestMethod]
        public void InsertProducts()
        {
            using (var db = new NorthwindDB("Northwind"))
            {
                var list = new List<Products>
                {
                    new Products
                    {
                        Category = new Categories
                        {
                            CategoryName = "Produce"
                        },
                        Supplier = new Suppliers
                        {
                            CompanyName = "Mayumi's"
                        },
                        ProductName = "Product1"
                    },
                    new Products
                    {
                        Category = new Categories
                        {
                            CategoryName = "Produce"
                        },
                        Supplier = new Suppliers
                        {
                            CompanyName = "Mayumi's1"
                        },
                        ProductName = "Product2"
                    },
                    new Products
                    {
                        Category = new Categories
                        {
                            CategoryName = "Produce1"
                        },
                        Supplier = new Suppliers
                        {
                            CompanyName = "Mayumi's2"
                        },
                        ProductName = "Product3"
                    }
                };

                db.Categories
                    .Merge()
                    .Using(list.Select(item => item.Category))
                    .On(item => item.CategoryName, item => item.CategoryName)
                    .InsertWhenNotMatched(source => new Categories
                    {
                        CategoryName = source.CategoryName
                    })
                    .Merge();

                db.Suppliers
                    .Merge()
                    .Using(list.Select(item => item.Supplier))
                    .On(item => item.CompanyName, item => item.CompanyName)
                    .InsertWhenNotMatched(source => new Suppliers
                    {
                        CompanyName = source.CompanyName
                    })
                    .Merge();


                list.ForEach(item => item.CategoryID = db.Categories.First(ct => ct.CategoryName == item.Category.CategoryName).CategoryID);

                list.ForEach(item => item.SupplierID = db.Suppliers.First(ct => ct.CompanyName == item.Supplier.CompanyName).SupplierID);

                db.Products
                    .Merge()
                    .Using(list)
                    .On(pr => pr.ProductName, pr => pr.ProductName)
                    .InsertWhenNotMatched(products => new Products
                    {
                        ProductName = products.ProductName,
                        CategoryID = products.CategoryID,
                        SupplierID = products.SupplierID
                    })
                    .Merge();
            }
        }

         [TestMethod]
        public void ProductsReplacement()
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;

            var db = new NorthwindDB("Northwind");

            var orders = db.OrderDetails.LoadWith(t => t.OrderDetailsOrder)
                .Where(order => order.OrderDetailsOrder.ShippedDate == null)
                .GroupBy(key => key.OrderID, 
                        (i, detailses) => new
                        {
                            OrderID = i,
                            PrductIDs = detailses.Where(item => item.OrderID == i).Select(item => item.ProductID).ToList()
                        }).ToList();

            db.Dispose();

            var rdm = new Random(DateTime.Now.Millisecond);

            using (db = new NorthwindDB("Northwind"))
            {
                foreach (var order in orders)
                {
                    int productid;
                    do
                    {
                        productid = rdm.Next(1, 77);
                    } while (order.PrductIDs.Contains(productid));

                    db.OrderDetails
                        .Where(item => item.OrderID == order.OrderID && item.ProductID == order.PrductIDs.First())
                        .Set(od => od.ProductID, productid)
                        .Set(od => od.Discount, (float)0.99)
                        .Update();
                }
            }
        }
    }
}
