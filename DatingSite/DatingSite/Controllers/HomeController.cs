using DataLayer;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatingSiteContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DatingSiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(LightProfile model)
        {
            try
            {
                var userRepository = new UserRepository(_context);
                var list = userRepository.GetFiveUsers();
                List<LightProfile> modelList = new List<LightProfile>();
                foreach (var user in list)
                {
                    LightProfile lightProfile = new LightProfile();
                    lightProfile.User = user;
                    modelList.Add(lightProfile);
                }

                return View(modelList);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        public IActionResult Privacy()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            try
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}