using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    //way to control what is put in there - defines the structure of the class
    public interface IBooksRepository
    {
        IQueryable<Book> Books { get; }
    }
}
