using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Shippers
    {
        [PrimaryKey, Identity]
        public int ShipperID { get; set; }

        [Column, NotNull]
        public string CompanyName { get; set; }

        [Column, Nullable]
        public string Phone { get; set; }

        [Association(ThisKey = "ShipperID", OtherKey = "ShipVia", CanBeNull = false)]
        public IEnumerable<Orders> Orders { get; set; }
    }
}
