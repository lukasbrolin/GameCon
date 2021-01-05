using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class ChangeGGPController : Controller
    {
        private readonly DatingSiteContext _context;

        public ChangeGGPController(DatingSiteContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(GGPViewModel model)
        {
            var userRepostitory = new UserRepository(_context);
            var gameRepository = new GameRepository(_context);
            var genreRepository = new GenreRepository(_context);
            var platformRepository = new PlatformRepository(_context);
            var userId = User.Identity.Name;

            List<Game> userGames = userRepostitory.GetUserGamesByMail(userId);
            List<Game> gameCollection = gameRepository.GetGames(); ;
            List<Platform> userPlatforms = userRepostitory.GetUserPlatformsByMail(userId);
            List<Platform> platformCollection = platformRepository.GetPlatforms();
            List<Genre> userGenres = userRepostitory.GetUserGenresByMail(userId);
            List<Genre> genreCollection = genreRepository.GetGenres();



            var userNonSelectedGames = gameCollection.Except(userGames).ToList();
            var userNonSelectedPlatforms = platformCollection.Except(userPlatforms).ToList();
            var userNonSelectedGenres = genreCollection.Except(userGenres).ToList();

            var modelGames = new Dictionary<Game, bool>();
            var modelPlatforms = new Dictionary<Platform, bool>();
            var modelGenres = new Dictionary<Genre, bool>();


            foreach (var x in userGames)
            {
                modelGames.Add(x, true);
            }
            foreach (var x in userNonSelectedGames)
            {
                modelGames.Add(x, false);
            }
            foreach (var x in userPlatforms)
            {
                modelPlatforms.Add(x, true);
            }
            foreach (var x in userNonSelectedPlatforms)
            {
                modelPlatforms.Add(x, false);
            }
            foreach (var x in userGenres)
            {
                modelGenres.Add(x, true);
            }
            foreach (var x in userNonSelectedGenres)
            {
                modelGenres.Add(x, false);
            }

            model.Games = modelGames;
            model.Platforms = modelPlatforms;
            model.Genres = modelGenres;


            return View(model);

        }

        [HttpPost]
        public ActionResult Submit(string[] CheckBoxes)
        {
            var userRepository = new UserRepository(_context);

            userRepository.SetUserGames(User.Identity.Name, CheckBoxes);
            userRepository.SetUserGenres(User.Identity.Name, CheckBoxes);
            userRepository.SetUserPlatforms(User.Identity.Name, CheckBoxes);

            return RedirectToAction("Index", "Profile");
        }

    }
}

