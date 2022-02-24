using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Textbook_Project.Models.ViewModels
{
    public class PageInfo
    {
        //Set values
        public int TotalBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        //Calculate 
        public int TotalPages => (int) Math.Ceiling((double) TotalBooks / BooksPerPage);
    }
}
