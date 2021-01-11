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

        //returns view with the names of all the available platforms and lets users select which one they like.
        public IActionResult Index()
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

        //postmethod for submitting the form. collect the answers from the checkboxes and sends them to this method.
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
    }
}