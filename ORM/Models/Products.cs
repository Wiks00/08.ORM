using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Products
    {
        [PrimaryKey, Identity]
        public int ProductID { get; set; }

        [Column, NotNull]
        public string ProductName { get; set; }

        [Column, Nullable]
        public int? SupplierID { get; set; }

        [Column, Nullable]
        public int? CategoryID { get; set; }

        [Column, Nullable]
        public string QuantityPerUnit { get; set; }

        [Column, Nullable]
        public decimal? UnitPrice { get; set; }

        [Column, Nullable]
        public short? UnitsInStock { get; set; }

        [Column, Nullable]
        public short? UnitsOnOrder { get; set; }

        [Column, Nullable]
        public short? ReorderLevel { get; set; }

        [Column, NotNull]
        public bool Discontinued { get; set; }

        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID", CanBeNull = true)]
        public Categories Category { get; set; }

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID", CanBeNull = true)]
        public Suppliers Supplier { get; set; }

        [Association(ThisKey = "ProductID", OtherKey = "ProductID", CanBeNull = false)]
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
