using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    //inherits from Bc Context
    public class BooksDBContext : DbContext
    {
        //constructor that inherits all the base options of db context
        public BooksDBContext (DbContextOptions<BooksDBContext> options) : base (options)
        {

        }
        public DbSet<Book> Books { get; set; }

    }
}
