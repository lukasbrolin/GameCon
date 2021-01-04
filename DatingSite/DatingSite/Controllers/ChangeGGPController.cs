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
        public ActionResult Index(GGPViewModel model, string profile)
        {
            var userRepostitory = new UserRepository(_context);

            foreach (var user in userRepostitory.getUserGamesGenresPlatformsScore(User.Identity.Name))
            {
                if (user.Item1.NickName.Equals(profile))
                {

                    model.User = user.Item1;
                    model.Games = user.Item2;
                    model.Genres = user.Item3;
                    model.Platforms = user.Item4;

                    break;
                }
                else if (user.Item1.Mail.Equals(User.Identity.Name))
                {
                    model.User = user.Item1;
                    model.Games = user.Item2;
                    model.Genres = user.Item3;
                    model.Platforms = user.Item4;

                    break;
                }
            }
            return View(model);
        }


    }
}

