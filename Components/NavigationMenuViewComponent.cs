using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooks.Models;

namespace OnlineBooks.Components
{
    public class NavigationMenuViewComponent :ViewComponent
    {
        private IBooksRepository _repository;
        
        public NavigationMenuViewComponent (IBooksRepository r)
        {
            _repository = r;
        }
        
        //set up component 
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //drop in a partial view
            return View(_repository.Books
                .Select(x => x.Classification)
                .Distinct()
                .OrderBy(x => x));

        }
    }
}
