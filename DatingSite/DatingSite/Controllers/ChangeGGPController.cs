using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using DatingSite.Data;
using DatingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class ChangeGGPController : Controller
    {
        private readonly DatingSiteContext _context;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ChangeGGPController(DatingSiteContext context, UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        //Return view with information about user
        public async Task<IActionResult> Index(GGPViewModel model)
        {
            try
            {
                var userRepostitory = new UserRepository(_context);
                var gameRepository = new GameRepository(_context);
                var genreRepository = new GenreRepository(_context);
                var platformRepository = new PlatformRepository(_context);
                var personalityRepository = new PersonalityRepository(_context);
                var nationalityRepository = new NationalityRepository(_context);
                var userId = User.Identity.Name;

                ViewBag.PList = personalityRepository.GetPersonalities();
                ViewBag.NList = nationalityRepository.GetNationalities();

                List<Game> userGames = userRepostitory.GetUserGamesByMail(userId);
                List<Game> gameCollection = gameRepository.GetGames(); ;
                List<Platform> userPlatforms = userRepostitory.GetUserPlatformsByMail(userId);
                List<Platform> platformCollection = platformRepository.GetPlatforms();
                List<Genre> userGenres = userRepostitory.GetUserGenresByMail(userId);
                List<Genre> genreCollection = genreRepository.GetGenres();
                User thisUser = userRepostitory.getUserByMail(userId);

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
                model.Gender = thisUser.Gender;
                model.Nationality = nationalityRepository.GetNationalityById(thisUser.NationalityId).Name;
                model.Personality = personalityRepository.GetPersonalityById(thisUser.PersonalityId).Description;

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //Edit and save user personal preferences such as favorite games/genres/platforms + personal information when Save Changes button is clicked
        [HttpPost]
        public async Task<ActionResult> Submit(string[] CheckBoxesGame, string[] CheckBoxesGenre, string[] CheckBoxesPlatform, GGPViewModel model, IFormFile file)
        {
            try
            {
                var userRepository = new UserRepository(_context);
                var gameRepository = new GameRepository(_context);
                var genreRepository = new GenreRepository(_context);
                var platformRepository = new PlatformRepository(_context);
                var user = User.Identity.Name;

                List<Game> userGames = userRepository.GetUserGamesByMail(User.Identity.Name);
                List<Genre> userGenres = userRepository.GetUserGenresByMail(User.Identity.Name);
                List<Platform> userPlatforms = userRepository.GetUserPlatformsByMail(User.Identity.Name);

                var removedGamesList = userGames.Except(gameRepository.GetGamesByNames(CheckBoxesGame)).Select(x => x.Name).ToArray();
                var newSelectedGames = gameRepository.GetGamesByNames(CheckBoxesGame).Except(userGames).Select(x => x.Name).ToArray();

                if (newSelectedGames.Length > 0)
                {
                    userRepository.SetUserGames(User.Identity.Name, newSelectedGames);
                }
                if (removedGamesList.Length > 0)
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

                if (model.NickName != null)
                {
                    userRepository.EditUserNickName(user, model.NickName);
                }

                if (model.FirstName != null)
                {
                    userRepository.EditUserFirstName(user, model.FirstName);
                }

                if (model.LastName != null)
                {
                    userRepository.EditUserLastName(user, model.LastName);
                }

                if (model.Age > 0)
                {
                    userRepository.EditUserAge(user, model.Age);
                }

                if (model.Gender != null)
                {
                    userRepository.EditUserGender(user, model.Gender);
                }

                if (model.Nationality != null)
                {
                    userRepository.EditUserNationality(user, model.Nationality);
                }

                if (model.Personality != null)
                {
                    userRepository.EditUserPersonality(user, model.Personality);
                }

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

                        userRepository.EditUserImgUrl(user, relPath);
                    }
                }

                return RedirectToAction("Index", "Profile");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}