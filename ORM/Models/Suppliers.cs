using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Suppliers
    {
        [PrimaryKey, Identity]
        public int SupplierID { get; set; }

        [Column, NotNull]
        public string CompanyName { get; set; }

        [Column, Nullable]
        public string ContactName { get; set; }

        [Column, Nullable]
        public string ContactTitle { get; set; }

        [Column, Nullable]
        public string Address { get; set; }

        [Column, Nullable]
        public string City { get; set; }

        [Column, Nullable]
        public string Region { get; set; }

        [Column, Nullable]
        public string PostalCode { get; set; }

        [Column, Nullable]
        public string Country { get; set; }

        [Column, Nullable]
        public string Phone { get; set; }

        [Column, Nullable]
        public string Fax { get; set; }

        [Column, Nullable]
        public string HomePage { get; set; }

        [Association(ThisKey = "SupplierID", OtherKey = "SupplierID", CanBeNull = false)]
        public IEnumerable<Products> Products { get; set; }
    }
}
