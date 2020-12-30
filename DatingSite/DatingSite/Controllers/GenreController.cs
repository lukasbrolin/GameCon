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

        [HttpPost]
        public ActionResult Submit(GenreViewModel model)
        {
            
            return RedirectToAction("Index", "Platform");
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
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
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
                return View();
            }
        }
    }
}
