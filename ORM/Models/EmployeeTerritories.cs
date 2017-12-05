using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class EmployeeTerritories
    {
        [PrimaryKey(1), NotNull]
        public int EmployeeID { get; set; }

        [PrimaryKey(2), NotNull]
        public string TerritoryID { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = false)]
        public Employees Employee { get; set; }

        [Association(ThisKey = "TerritoryID", OtherKey = "TerritoryID", CanBeNull = false)]
        public Territories Territory { get; set; }
    }
}
