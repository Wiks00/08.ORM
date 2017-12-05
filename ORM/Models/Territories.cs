using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Territories
    {
        [PrimaryKey, NotNull]
        public string TerritoryID { get; set; }

        [Column, NotNull]
        public string TerritoryDescription { get; set; }

        [Column, NotNull]
        public int RegionID { get; set; }

        [Association(ThisKey = "RegionID", OtherKey = "RegionID", CanBeNull = false)]
        public Region Region { get; set; }

        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID", CanBeNull = false)]
        public IEnumerable<EmployeeTerritories> EmployeeTerritories { get; set; }
    }
}
