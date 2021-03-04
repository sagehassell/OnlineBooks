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

        //create a private repository
        private IBooksRepository _repository;
        // this is a git comment

        //specify how many you want per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            //set the private vars = to the public vars
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1) //default go to page 1
        {
            //pass in the Book objects
            return View(new BookListViewModel
            {
                Books = _repository.Books
                    //querey writen out in the language link
                    .Where(p => category == null || p.Classification == category)
                    .OrderBy(p => p.BookId)
                    .Skip((page -1) * PageSize)
                    .Take(PageSize)
                    ,
                PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ? _repository.Books.Count() :
                            _repository.Books.Where(x => x.Classification == category).Count()
                    },
                CurrentClassification = category
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
