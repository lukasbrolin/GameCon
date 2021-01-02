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
            var personalityRepo = new PersonalityRepository(_context);
            var nationalityRepo = new NationalityRepository(_context);
            ViewBag.PList = personalityRepo.GetPersonalities();
            ViewBag.NList = nationalityRepo.GetNationalities();
            Console.WriteLine(personalityRepo.getAll().Count);
            foreach(var d in personalityRepo.getAll())
            {
                Console.WriteLine(d);
            }
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, IFormFile file)
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
            user.ImgUrl = "Default";


            if (file != null)
            {
                try
                {

                    string imgUrl = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);


                    // Till utvecklarna: Spara inte på för långa sökvägar. Windows begränsar längden på sökvägen och bilden kan ej sparas. 
                    if (imgUrl.ToLower().Contains(".jpeg") || imgUrl.ToLower().Contains(".jpg") || imgUrl.Contains(".png"))
                    {
                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\avatars", imgUrl);
                        string relPath = System.IO.Path.Combine("~/img/avatars/" + imgUrl);
                        /*string savePath = Path.Combine("C:\\", imgName);*/
                        using (var fileStream = new FileStream(savePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }


                        user.ImgUrl = relPath;

                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            userRepo.AddUser(user);


            return RedirectToAction("Index", "Games");
        }
    }
}