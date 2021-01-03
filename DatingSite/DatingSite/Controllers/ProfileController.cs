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
    public class ProfileController : Controller
    {
        private readonly DatingSiteContext _context;

        public ProfileController(DatingSiteContext context)
        {
            _context = context;
        }
        // GET: ProfileController
        public ActionResult Index(ProfileViewModel model, string profile)
        {
            var visitorRepository = new VisitRepository(_context);
            var userRepository = new UserRepository(_context);
            var nationalityRepository = new NationalityRepository(_context);
            var personalityRepository = new PersonalityRepository(_context);
            var list = userRepository.GetUsers();
            //model.Users = list;
            //model.UserGamesGenrePlatforms = userRepository.getUserGames(User.Identity.Name);
            List<CardViewModel> modelList = new List<CardViewModel>();
            //foreach(var x in model.UserGames)
            //{
            //    Console.WriteLine(x);
            //}
            foreach (var user in userRepository.getUserGamesGenresPlatformsScore(User.Identity.Name))
            {
                if (user.Item1.NickName.Equals(profile))
                {
                    var usersVisits = userRepository.GetUserVisitorsByMail(user.Item1.Mail);

                    user.Item1.Nationality = nationalityRepository.GetNationalityById(user.Item1.NationalityId);
                    user.Item1.Personality = personalityRepository.GetPersonalityById(user.Item1.PersonalityId);
                    model.User = user.Item1;
                    model.Games = user.Item2;
                    model.Genres = user.Item3;
                    model.Platforms = user.Item4;
                    model.Visits = usersVisits;

                    //model.Score = user.Item5;
                    break;
                }
                else if (user.Item1.Mail.Equals(User.Identity.Name))
                {
                    var usersVisits = userRepository.GetUserVisitorsByMail(User.Identity.Name);

                    user.Item1.Nationality = nationalityRepository.GetNationalityById(user.Item1.NationalityId);
                    user.Item1.Personality = personalityRepository.GetPersonalityById(user.Item1.PersonalityId);
                    model.User = user.Item1;
                    model.Games = user.Item2;
                    model.Genres = user.Item3;
                    model.Platforms = user.Item4;
                    model.Visits = usersVisits;

                    //model.Score = user.Item5;
                    break;
                }

            }
            return View(model);
        }

        public ActionResult Visitors(VisitorViewModel model)
        {
            return View(model);
        }

                        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
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

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
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

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
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
