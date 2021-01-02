using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public IActionResult Index(string searchText)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
