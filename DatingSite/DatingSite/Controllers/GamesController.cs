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

        public async Task<IActionResult> Index()
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


            //model.AddRange(new ProfileViewModel(gameRepository.GetGamesNames))
            //return View(await _context.Games.ToListAsync());
        }

        [HttpPost]
        public ActionResult Submit(string[] CheckBoxes)
        {
            try
            {
                var userRepository = new UserRepository(_context);
                //var list = new List<string>();
                //foreach (var index in model)
                //{
                //    list.Add(index.Name);
                //}
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