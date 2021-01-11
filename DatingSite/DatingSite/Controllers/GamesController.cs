using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Models;
using DatingSite.Models;
using DataLayer.Repositories;

namespace DatingSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly DatingSiteContext _context;

        public GamesController(DatingSiteContext context)
        {
            _context = context;
        }

        //last step in the registration process. Lets the user select from available games in the list.
        public IActionResult Index()
        {
            try
            {
                var gameRepository = new GameRepository(_context);
                List<GameViewModel> model = new List<GameViewModel>();
                foreach (var index in gameRepository.GetGamesNames())
                {
                    model.Add(new GameViewModel(index));
                }
                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for handling the submitted answers from the users.
        [HttpPost]
        public ActionResult Submit(string[] CheckBoxes)
        {
            try
            {
                var userRepository = new UserRepository(_context);
                userRepository.SetUserGames(User.Identity.Name, CheckBoxes);
                return RedirectToAction("Index", "Genre");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}