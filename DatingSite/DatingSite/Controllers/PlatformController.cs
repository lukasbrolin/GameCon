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
    public class PlatformController : Controller
    {
        private readonly DatingSiteContext _context;
        // GET: PlatformController
        public PlatformController(DatingSiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var platformRepository = new PlatformRepository(_context);
            List<PlatformViewModel> model = new List<PlatformViewModel>();
            foreach (var index in platformRepository.GetPlatformNames())
            {
                model.Add(new PlatformViewModel(index));
            }
            //model.AddRange(new ProfileViewModel(gameRepository.GetGamesNames))
            //return View(await _context.Games.ToListAsync());
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(PlatformViewModel model)
        {

            return RedirectToAction("Index", "Home");
        }

        // GET: PlatformController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlatformController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatformController/Create
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

        // GET: PlatformController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlatformController/Edit/5
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

        // GET: PlatformController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlatformController/Delete/5
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
