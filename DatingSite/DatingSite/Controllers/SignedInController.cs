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
            try
            {
                var userRepository = new UserRepository(_context);
                var nationalityRepository = new NationalityRepository(_context);
                var personalityRepository = new PersonalityRepository(_context);
                var scoreCalculator = new ScoreCalculator(_context);
                var list = userRepository.GetUsers();
                List<CardViewModel> modelList = new List<CardViewModel>();
                foreach (var user in userRepository.getUserGamesGenresPlatformsScore(User.Identity.Name))
                {
                    if (!user.Item1.Mail.Equals(User.Identity.Name) && user.Item1.Active == true)
                    {
                        user.Item1.Nationality = nationalityRepository.GetNationalityById(user.Item1.NationalityId);
                        user.Item1.Personality = personalityRepository.GetPersonalityById(user.Item1.PersonalityId);
                        CardViewModel CModel = new CardViewModel();

                        CModel.User = user.Item1;
                        CModel.Games = user.Item2;
                        CModel.Genres = user.Item3;
                        CModel.Platforms = user.Item4;
                        CModel.Score = user.Item5;
                        CModel.ScoreDescription = scoreCalculator.ScoreDescription(user.Item5);

                        modelList.Add(CModel);
                    }
                }
                return View(modelList);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        // GET: SignedInController/Details/5
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

        // GET: SignedInController/Create
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

        // POST: SignedInController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SignedInController/Edit/5
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

        // POST: SignedInController/Edit/5
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

        // GET: SignedInController/Delete/5
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

        // POST: SignedInController/Delete/5
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