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

        //startpage for when a user finishes the registration and is shown other users profile as a card.
        public ActionResult Index(CardViewModel model)
        {
            //fetches each users information and preferences and displays it in a card for other users to see.
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
    }
}