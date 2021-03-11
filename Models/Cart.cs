using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class Cart
    {
     
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        
        //adding an item 
        public virtual void AddItem (Book book, int quantity)
        {
            //build new instance of the object
            CartLine line = Lines.Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            //check and see if we have added the book already
            if (line ==null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //removing an Book
        public virtual void RemoveLine(Book bk) =>
            Lines.RemoveAll(x => x.Book.BookId == bk.BookId);

        //remove all from Cart
        public virtual void Clear() => Lines.Clear();

        
        //comput total cart sum
        public float ComputeTotalSum()
        {
            return (Lines.Sum(e => e.Book.Price * e.Quantity));
        }


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }

        }
    }
}
