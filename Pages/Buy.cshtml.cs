using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBooks.Infastructure;
using OnlineBooks.Models;
using OnlineBooks.Infastructure;

namespace OnlineBooks.Pages
{
    public class BuyModel : PageModel
    {
        private IBooksRepository repository;

        //Constructor
        public BuyModel (IBooksRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string  ReturnUrl { get; set; }

        //Methods

        //get
        public void OnGet(string returnUrl)
        {
            ReturnUrl = ReturnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //post
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(predicate => predicate.BookId == bookId);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        //remove
        public IActionResult OnPostRemove (long bookId, string returnUrl)
        {
            //Book book = repository.Books.FirstOrDefault(predicate => predicate.BookId == bookId);
            //Cart.RemoveLine(book);

            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookId == bookId).Book);

            return RedirectToPage(new{ returnUrl = returnUrl});
        }

    }
}
