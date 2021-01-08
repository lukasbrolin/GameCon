using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

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
            try
            {
                var personalityRepo = new PersonalityRepository(_context);
                var nationalityRepo = new NationalityRepository(_context);
                ViewBag.PList = personalityRepo.GetPersonalities();
                ViewBag.NList = nationalityRepo.GetNationalities();
                return View(new RegisterViewModel());
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, IFormFile file)
        {
            try
            {
                var userRepo = new UserRepository(_context);
                var nationalityRepo = new NationalityRepository(_context);
                var personalityRepo = new PersonalityRepository(_context);
                var user = new User();

                user.NickName = model.NickName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Mail = User.Identity.Name;
                user.Age = model.Age;
                user.Gender = model.Gender;
                user.NationalityId = nationalityRepo.GetNationalityIdByName(model.Nationality);
                user.PersonalityId = personalityRepo.GetPersonalityIdByName(model.Personality);
                user.Active = true;
                user.Online = true;

                if (file != null)
                {
                    string imgUrl = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (imgUrl.ToLower().Contains(".jpeg") || imgUrl.ToLower().Contains(".jpg") || imgUrl.Contains(".png"))
                    {
                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\avatars", imgUrl);
                        string relPath = System.IO.Path.Combine("~/img/avatars/" + imgUrl);
                        using (var fileStream = new FileStream(savePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        user.ImgUrl = relPath;
                    }
                }
                userRepo.AddUser(user);
                return RedirectToAction("Index", "Games");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }
    }
}