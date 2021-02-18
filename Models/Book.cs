using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class Book
    {
        //primary key
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleInitial { get; set; }
        [Required]
        public string  AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }

        //check the ISBN format is valid
        [Required]
        [RegularExpression(@"ISBN(-1(?:(0)|3))?:?\x20(\s)*[0-9]+[- ][0-9]+[- ][0-9]+[- ][0-9]*[- ]*[xX0-9]",
                   ErrorMessage = "Entered ISBN format is not valid.")]
        public int ISBN { get; set; }
        [Required]
        public float Price { get; set; }
        //create atomic catigories 
        [Required]
        public string Category { get; set; }
        [Required]
        public string Classification { get; set; }
    }
}
