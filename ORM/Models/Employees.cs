using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class Employees
    {
        [PrimaryKey, Identity]
        public int EmployeeID { get; set; }

        [Column, NotNull]
        public string LastName { get; set; }

        [Column, NotNull]
        public string FirstName { get; set; }

        [Column, Nullable]
        public string Title { get; set; }

        [Column, Nullable]
        public string TitleOfCourtesy { get; set; }

        [Column, Nullable]
        public DateTime? BirthDate { get; set; }

        [Column, Nullable]
        public DateTime? HireDate { get; set; }

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
        public string HomePhone { get; set; }

        [Column, Nullable]
        public string Extension { get; set; }

        [Column, Nullable]
        public byte[] Photo { get; set; }

        [Column, Nullable]
        public string Notes { get; set; }

        [Column, Nullable]
        public int? ReportsTo { get; set; }

        [Column, Nullable]
        public string PhotoPath { get; set; }

        [Association(ThisKey = "ReportsTo", OtherKey = "EmployeeID", CanBeNull = true)]
        public Employees FK_Employees_Employee { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "ReportsTo", CanBeNull = false)]
        public IEnumerable<Employees> FK_Employees_Employees_BackReferences { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = false)]
        public IEnumerable<Orders> Orders { get; set; }

        [Association(ThisKey = "EmployeeID", OtherKey = "EmployeeID", CanBeNull = false)]
        public IEnumerable<EmployeeTerritories> EmployeeTerritories { get; set; }
    }
}
