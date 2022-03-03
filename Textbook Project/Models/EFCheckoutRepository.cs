using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Textbook_Project.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository(BookstoreContext cont)
        {
            context = cont;
        }
        public IQueryable<Checkout> Checkouts => context.Checkout.Include(x => x.Items).ThenInclude(x=>x.Book);

        public void SaveCheckout(Checkout check)
        {
            context.AttachRange(check.Items.Select(x => x.Book));

            if (check.CheckoutId == 0)
            {
                context.Checkout.Add(check);
            }
            context.SaveChanges();
        }
    
    }
}
