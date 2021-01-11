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
    public class ChatController : Controller
    {
        private readonly DatingSiteContext _context;

        public ChatController(DatingSiteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}