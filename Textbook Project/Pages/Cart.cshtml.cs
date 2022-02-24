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
        public CartModel (IBookRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.BookLibrary.FirstOrDefault(x => x.BookId == bookid);
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);
            HttpContext.Session.SetJson("basket", basket);
            return RedirectToPage( new { ReturnUrl = returnUrl });
        }
    }
}