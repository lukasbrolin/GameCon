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
        // GET: GenreController
        public async Task<IActionResult> Index()
        {
            try
            {
                var genreRepository = new GenreRepository(_context);
                List<GenreViewModel> model = new List<GenreViewModel>();
                foreach (var index in genreRepository.GetGenreNames())
                {
                    model.Add(new GenreViewModel(index));
                }
                //model.AddRange(new ProfileViewModel(gameRepository.GetGamesNames))
                //return View(await _context.Games.ToListAsync());

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }


        }

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

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}
