using LinqToDB;
using LinqToDB.Data;
using ORM.Models;

namespace ORM
{
    public class NorthwindDB : DataConnection
    {
        public ITable<Categories> Categories => GetTable<Categories>();

        public ITable<Customers> Customers => GetTable<Customers>();

        public ITable<CustomerCustomerDemo> CustomerCustomerDemoes => GetTable<CustomerCustomerDemo>();

        public ITable<CustomerDemographics> CustomerDemographics => GetTable<CustomerDemographics>();

        public ITable<Employees> Employees => GetTable<Employees>();

        public ITable<EmployeeTerritories> EmployeeTerritories => GetTable<EmployeeTerritories>();

        public ITable<Orders> Orders => GetTable<Orders>();

        public ITable<OrderDetails> OrderDetails => GetTable<OrderDetails>();

        public ITable<Products> Products => GetTable<Products>();

        public ITable<Region> Regions => GetTable<Region>();

        public ITable<Shippers> Shippers => GetTable<Shippers>();

        public ITable<Suppliers> Suppliers => GetTable<Suppliers>();

        public ITable<Territories> Territories => GetTable<Territories>();

        public NorthwindDB()
        {
        }

        public NorthwindDB(string configuration)
            : base(configuration)
        {
            
        }
    }
}