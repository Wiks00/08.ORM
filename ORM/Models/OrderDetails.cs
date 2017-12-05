using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind", Name = "Order Details")]
    public class OrderDetails
    {
        [PrimaryKey(1), NotNull]
        public int OrderID { get; set; }

        [PrimaryKey(2), NotNull]
        public int ProductID { get; set; }

        [Column, NotNull]
        public decimal UnitPrice { get; set; }

        [Column, NotNull]
        public short Quantity { get; set; }

        [Column, NotNull]
        public float Discount { get; set; }

        [Association(ThisKey = "OrderID", OtherKey = "OrderID", CanBeNull = false)]
        public Orders OrderDetailsOrder { get; set; }

        [Association(ThisKey = "ProductID", OtherKey = "ProductID", CanBeNull = false)]
        public Products OrderDetailsProduct { get; set; }
    }
}
