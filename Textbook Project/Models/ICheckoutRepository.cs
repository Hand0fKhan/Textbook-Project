using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Textbook_Project.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkouts { get; }


        public void SaveCheckout(Checkout check);
    }
}
