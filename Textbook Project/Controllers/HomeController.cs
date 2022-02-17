using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Textbook_Project.Models;
using Textbook_Project.Models.ViewModels;

namespace Textbook_Project.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository repo;
        public HomeController(IBookRepository temp)
        {
            repo = temp;
        }


        //For pulling info from repositories to webpage
        public IActionResult Index(int pageNum = 1)
        {
            int pageCt = 10;

            var BookPage = new ProjectViewModel
            {
                Books = repo.BookLibrary.
                OrderBy(b => b.Title).
                Skip((pageNum - 1) * pageCt).
                Take(pageCt),

                PageInfo = new PageInfo
                {
                    TotalBooks = repo.BookLibrary.Count(),
                    BooksPerPage = pageCt,
                    CurrentPage = pageNum
                }
            };

            return View(BookPage);
        }
    }
}
