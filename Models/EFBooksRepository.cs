using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BooksDBContext _context; //context is th DB set of projects
        
        //the constructor
        public EFBooksRepository (BooksDBContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
