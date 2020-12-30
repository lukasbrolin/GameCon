using DataLayer;
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

        // GET: SignedInController
        public ActionResult Index()
        {
            return View();
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