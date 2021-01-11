using DataLayer;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class GenreController : Controller
    {
        private readonly DatingSiteContext _context;

        public GenreController(DatingSiteContext context)
        {
            _context = context;
        }

        //displays view about the different genres available and lets users chose from them.
        public IActionResult Index()
        {
            try
            {
                var genreRepository = new GenreRepository(_context);
                List<GenreViewModel> model = new List<GenreViewModel>();
                foreach (var index in genreRepository.GetGenreNames())
                {
                    model.Add(new GenreViewModel(index));
                }

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for handling the submitted answers from the users.
        [HttpPost]
        public ActionResult Submit(string[] CheckBoxes)
        {
            try
            {
                var userRepository = new UserRepository(_context);
                userRepository.SetUserGenres(User.Identity.Name, CheckBoxes);
                return RedirectToAction("Index", "Platform");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}