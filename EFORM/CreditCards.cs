using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFORM
{

    [Table("Northwind.CreditCards")]
    public partial class CreditCards
    {
        public CreditCards()
        {
        }

        [Key]
        public int CreditCardID { get; set; }

        [Required]
        public int CardNumber { get; set; }

        [Required]
        public DateTime ExperationDate { get; set; }

        [Required]
        public string CardHolder { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
