using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Orders
    {
        [PrimaryKey, Identity]
        public int OrderID { get; set; }

        [Column, Nullable]
        public string CustomerID { get; set; }

        [Column, Nullable]
        public int? EmployeeID { get; set; }

        [Column, Nullable]
        public DateTime? OrderDate { get; set; }

        [Column, Nullable]
        public DateTime? RequiredDate { get; set; }

        [Column, Nullable]
        public DateTime? ShippedDate { get; set; }

        [Column, Nullable]
        public int? ShipVia { get; set; }

        [Column, Nullable]
        public decimal? Freight { get; set; }

        [Column, Nullable]
        public string ShipName { get; set; }

        [Column, Nullable]
        public string ShipAddress { get; set; }

        [Column, Nullable]
        public string ShipCity { get; set; }

        [Column, Nullable]
        public string ShipRegion { get; set; }

        [Column, Nullable]
        public string ShipPostalCode { get; set; }

        [Column, Nullable]
        public string ShipCountry { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = true)]
        public Customers Customer { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = true)]
        public Employees Employee { get; set; }

        [Association(ThisKey = "ShipVia", OtherKey = "ShipperID", CanBeNull = true)]
        public Shippers Shipper { get; set; }

        [Association(ThisKey = "OrderID", OtherKey = "OrderID", CanBeNull = false)]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
