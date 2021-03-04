using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    //Tells the program how to access/query the DB/makes CRUD possible
    public class BooksDBContext : DbContext
    {
        //constructor that inherits all the base options of db context
        public BooksDBContext (DbContextOptions<BooksDBContext> options) : base (options)
        {

        }

        //list of 'Boks.cs' objects
        public DbSet<Book> Books { get; set; }

    }
}
 