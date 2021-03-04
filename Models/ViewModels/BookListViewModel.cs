using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models.ViewModels
{
    //the view that will be handed to the project - has 2 sets of info
    public class BookListViewModel
    {
        //info about the project
        public IEnumerable<Book> Books { get; set; }

        //info about the page number
        public PagingInfo PagingInfo { get; set; }

        //what category is the book in
        public string CurrentClassification { get; set; }
    }
}
