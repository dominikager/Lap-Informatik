using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lagerverwaltung.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [StringLength(200), MaxLength(200), Required, DisplayName("Vorgangstyp")]
        public string Name { get; set; }
    }
}