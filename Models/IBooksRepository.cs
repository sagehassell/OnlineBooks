using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    //way to control what is put in there - defines the structure of the class
    public interface IBooksRepository //interface is a template that is meant to be inherited
    {
        //puts the info in a class that makes it easier to querey from
        IQueryable<Book> Books { get; }
    }
}
