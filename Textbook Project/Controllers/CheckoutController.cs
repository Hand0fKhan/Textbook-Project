using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Textbook_Project.Models;

namespace Textbook_Project.Controllers
{ 
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController(ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        public IActionResult Index()
        {
            return View(new Checkout());
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult CheckOut(Checkout check)
        {
            if(basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                check.Items = basket.Items.ToArray();
                repo.SaveCheckout(check);
                basket.ClearBasket();

                return RedirectToPage("/Confirm");
            }
            else
            {
                return View();
            }
        }
    }
}
