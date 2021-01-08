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
            try
            {
                var platformRepository = new PlatformRepository(_context);
                List<PlatformViewModel> model = new List<PlatformViewModel>();
                foreach (var index in platformRepository.GetPlatformNames())
                {
                    model.Add(new PlatformViewModel(index));
                }
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
                userRepository.SetUserPlatforms(User.Identity.Name, CheckBoxes);
                return RedirectToAction("Index", "SignedIn");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        // GET: PlatformController/Details/5
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

        // GET: PlatformController/Create
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

        // POST: PlatformController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        // GET: PlatformController/Edit/5
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

        // POST: PlatformController/Edit/5
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

        // GET: PlatformController/Delete/5
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

        // POST: PlatformController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}