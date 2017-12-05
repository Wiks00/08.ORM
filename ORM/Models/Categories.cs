using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Categories
    {
        [PrimaryKey, Identity]
        public int CategoryID { get; set; }

        [Column, NotNull]
        public string CategoryName { get; set; }

        [Column, Nullable]
        public string Description { get; set; }

        [Column, Nullable]
        public byte[] Picture { get; set; }

        [Association(ThisKey = "CategoryID", OtherKey = "CategoryID", CanBeNull = false)]
        public IEnumerable<Products> Products { get; set; }
    }
}
