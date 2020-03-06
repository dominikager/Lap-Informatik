using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkiVerleih.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(200), MaxLength(200), DisplayName("Vorname")]
        public string FirstName { get; set; }

        [Required, StringLength(200), MaxLength(200), DisplayName("Nachname")]
        public string LastName { get; set; }

        [Required, StringLength(200), MaxLength(200), DisplayName("Email")]
        public string Email { get; set; }

        [Required, StringLength(200), MaxLength(200), DisplayName("Telefon")]
        public string Phone { get; set; }

        public virtual IEnumerable<RentedArticle> RentedArticles { get; set; }

        public string getFullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}