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
                        ISBN = "978-3642117466",
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
                        ISBN = "978-0451419439",
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
                        ISBN = "978-1455523023",
                        Price = 14.99f,
                        Category = "Non-Fiction",
                        Classification = "Self-Help"
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleInitial = "K",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Price = 14.59f,
                        Category = "Non-Fiction",
                        Classification = "Biography"
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Price = 14.99f,
                        Category = "Non-Fiction",
                        Classification = "Biography"
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleInitial = "C",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Price = 11.61f,
                        Category = "Non-Fiction",
                        Classification = "Biography"
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Price = 15.95f,
                        Category = "Fiction",
                        Classification = "Historical Fiction"
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Price = 21.66f,
                        Category = "Non-Fiction",
                        Classification = "Self-Help"
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Brandson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Price = 29.16f,
                        Category = "Non-Fiction",
                        Classification = "Business"
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Price = 15.03f,
                        Category = "Non-Fiction",
                        Classification = "Thrillers"
                    }




                );
                //save the changes
                context.SaveChanges();
            }
        }

    }
}
