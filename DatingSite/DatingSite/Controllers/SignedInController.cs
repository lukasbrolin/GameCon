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
    public class SignedInController : Controller
    {
        private readonly DatingSiteContext _context;

        public SignedInController(DatingSiteContext context)
        {
            _context = context;
        }

        public ActionResult Index(CardViewModel model)
        {
            var userRepository = new UserRepository(_context);
            var list = userRepository.GetUsers();
            model.Users = list;
            return View(model);
        }

        // GET: SignedInController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignedInController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignedInController/Create
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

        // GET: SignedInController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignedInController/Edit/5
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

        // GET: SignedInController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignedInController/Delete/5
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