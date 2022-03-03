using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Textbook_Project.Infrastructure;
using Textbook_Project.Models;

namespace Textbook_Project.Pages
{
    public class CartModel : PageModel
    {

        private IBookRepository repo { get; set; }
        public CartModel (IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";        
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.BookLibrary.FirstOrDefault(x => x.BookId == bookid);
            basket.AddItem(b, 1);
            return RedirectToPage( new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
