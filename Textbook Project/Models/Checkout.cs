using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Textbook_Project.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        [BindNever]
        public ICollection<BasketItem>Items { get; set; }
        [Required (ErrorMessage ="Please enter a name: ")]
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required (ErrorMessage ="Please enter a city: ")]
        public string City { get; set; }
        [Required (ErrorMessage ="Please enter a State: ")]
        public string State { get; set; }
        [Required (ErrorMessage = "Please enter a Country: ")]
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}
