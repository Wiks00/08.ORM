using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Region
    {
        [PrimaryKey, NotNull]

        public int RegionID { get; set; }

        [Column, NotNull]
        public string RegionDescription { get; set; }

        [Association(ThisKey = "RegionID", OtherKey = "RegionID", CanBeNull = false)]
        public IEnumerable<Territories> Territories { get; set; }
    }
}
