using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Textbook_Project.Models
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public virtual void AddItem(Book book, int qty)
        {
            BasketItem line = Items.Where(p => p.Book.BookId == book.BookId).FirstOrDefault();
            if (line == null)
            {
                Items.Add(new BasketItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual double CalcTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }

        public virtual double CalcTax()
        {
            double sum = (Items.Sum(x => x.Quantity * x.Book.Price)) +
                (Items.Sum(x => x.Quantity * x.Book.Price)) * .061;
            return sum;
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public virtual void RemoveItem(Book temp)
        {
            Items.RemoveAll(x => x.Book.BookId == temp.BookId);
        }
    }

    public class BasketItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}

