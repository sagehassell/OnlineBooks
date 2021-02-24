using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models.ViewModels
{
    public class BookListViewModel
    {
        //info about the project
        public IEnumerable<Book> Books { get; set; }

        //info about the page number
        public PagingInfo PagingInfo { get; set; }
    }
}
