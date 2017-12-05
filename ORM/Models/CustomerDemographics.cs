using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace ORM.Models
{
    [Table(Schema = "Northwind")]
    public class CustomerDemographics
    {
        [PrimaryKey, NotNull]
        public string CustomerTypeID { get; set; }

        [Column, Nullable]
        public string CustomerDesc { get; set; }

        [Association(ThisKey = "CustomerTypeID", OtherKey = "CustomerTypeID", CanBeNull = false)]
        public IEnumerable<CustomerCustomerDemo> CustomerCustomerDemoes { get; set; }
    }
}
