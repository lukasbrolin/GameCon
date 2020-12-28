using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatingSite.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DatingSiteContext _context;

        public RegisterController(DatingSiteContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var user = new User();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Mail = User.Identity.Name;
            user.Age = model.Age;
            user.Gender = model.Gender;
            user.NationalityId = model.Nationality;
            user.PreferedLanguage = model.Language;
            user.PersonalityId = model.Personality;
            user.Active = true;
            user.Online = true;

            var userRepo = new UserRepository(_context);
            userRepo.AddUser(user);
            //return RedirectToPage("RegisterConfirmation");
            return RedirectToPage("RegisterConfirmation", new { email = user.Mail });
        }
    }
}