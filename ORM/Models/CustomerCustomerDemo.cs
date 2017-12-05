using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class CustomerCustomerDemo
    {
        [PrimaryKey(1), NotNull]
        public string CustomerID { get; set; }

        [PrimaryKey(2), NotNull]
        public string CustomerTypeID { get; set; }

        [Association(ThisKey = "CustomerTypeID", OtherKey = "CustomerTypeID", CanBeNull = false)]
        public CustomerDemographics FK_CustomerCustomerDemo { get; set; }

        [Association(ThisKey = "CustomerID", OtherKey = "CustomerID", CanBeNull = false)]
        public Customers Customer { get; set; }
    }
}
