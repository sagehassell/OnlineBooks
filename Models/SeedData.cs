using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BooksDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<BooksDBContext>();
        
            //check to see if there are any pending migrations
            if(context.Database.GetPendingMigrations().Any())
            {
                //Migrate those 
                context.Database.Migrate();
            }
            //if there aren't any books, fill it with this
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = 978-3-642-11746-6,
                        Price = 13.33f,
                        Category = "Non-Fiction",
                        Classification = "Historical"
                    },

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = 978-0-451-41943-9,
                        Price = 9.95f,
                        Category = "Non-Fiction",
                        Classification = "Historical"
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = 978-1-455-52302-3,
                        Price = 14.99f,
                        Category = "Non-Fiction",
                        Classification = "Self-Help"
                    }
                );
                //save the changes
                context.SaveChanges();
            }
        }

    }
}
