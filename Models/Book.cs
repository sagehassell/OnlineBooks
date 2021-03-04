using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


//databases in ASP.NET do NOT have to build from the models
//databases is NOT automatically normalized
//creating databases from the models = "Migration"

namespace OnlineBooks.Models
{
    public class Book
    {
        //primary key in the model 
        [Key]
        [Required]
        //Having the letters Id after the title 
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        //public string? Title { get; set; } - adding the question mark makes it 
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleInitial { get; set; }
        [Required]
        public string  AuthorLastName { get; set; }
        [Required]
        public int PageNumber { get; set; }
        [Required]
        public string Publisher { get; set; }

        //check the ISBN format is valid
        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$",
                   ErrorMessage = "Entered ISBN format is not valid.")]
        public string ISBN { get; set; }
        [Required]
        public float Price { get; set; }
        //create atomic catigories 
        [Required]
        public string Category { get; set; }
        [Required]
        public string Classification { get; set; }
    }
}
