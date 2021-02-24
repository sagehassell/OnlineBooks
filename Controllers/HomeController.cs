using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBooks.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooks.Models.ViewModels;

namespace OnlineBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBooksRepository _repository;
        //specify how many you want per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            //pass in the Book objects
            return View(new BookListViewModel
            {
                Books = _repository.Books
                    //querey writen out in the language link
                    .OrderBy(p => p.BookId)
                    .Skip((page -1) * PageSize)
                    .Take(PageSize)
                    ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = _repository.Books.Count()
                    }
            });                    
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
