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
        public ActionResult Submit(string[] CheckBoxesGame,string[] CheckBoxesGenre,string[] CheckBoxesPlatform)
        {
            var userRepository = new UserRepository(_context);
            var gameRepository = new GameRepository(_context);
            var genreRepository = new GenreRepository(_context);
            var platformRepository = new PlatformRepository(_context);

            List<Game> userGames = userRepository.GetUserGamesByMail(User.Identity.Name);
            List<Genre> userGenres = userRepository.GetUserGenresByMail(User.Identity.Name);
            List<Platform> userPlatforms = userRepository.GetUserPlatformsByMail(User.Identity.Name);


            var removedGamesList = userGames.Except(gameRepository.GetGamesByNames(CheckBoxesGame)).Select(x => x.Name).ToArray();
            var newSelectedGames = gameRepository.GetGamesByNames(CheckBoxesGame).Except(userGames).Select(x => x.Name).ToArray();
            if(newSelectedGames.Length > 0)
            {
                userRepository.SetUserGames(User.Identity.Name, newSelectedGames);
            }
            if(removedGamesList.Length > 0)
            {
                userRepository.RemoveUserGames(User.Identity.Name, removedGamesList);
            }

            var removedGenreList = userGenres.Except(genreRepository.GetGenresByNames(CheckBoxesGenre)).Select(x => x.Name).ToArray();
            var newSelectedGenre = genreRepository.GetGenresByNames(CheckBoxesGenre).Except(userGenres).Select(x => x.Name).ToArray();
            if (newSelectedGenre.Length > 0)
            {
                userRepository.SetUserGenres(User.Identity.Name, newSelectedGenre);
            }
            if (removedGenreList.Length > 0)
            {
                userRepository.RemoveUserGenres(User.Identity.Name, removedGenreList);
            }

            var removedPlatformsList = userPlatforms.Except(platformRepository.GetPlatformsByNames(CheckBoxesPlatform)).Select(x => x.Name).ToArray();
            var newSelectedPlatforms = platformRepository.GetPlatformsByNames(CheckBoxesPlatform).Except(userPlatforms).Select(x => x.Name).ToArray();
            if (newSelectedPlatforms.Length > 0)
            {
                userRepository.SetUserPlatforms(User.Identity.Name, newSelectedPlatforms);
            }
            if (removedPlatformsList.Length > 0)
            {
                userRepository.RemoveUserPlatforms(User.Identity.Name, removedPlatformsList);
            }


            //userRepository.SetUserGenres(User.Identity.Name, CheckBoxes);
            //userRepository.SetUserPlatforms(User.Identity.Name, CheckBoxes);

            return RedirectToAction("Index", "Profile");
        }

    }
}

