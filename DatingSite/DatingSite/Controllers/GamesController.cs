using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Models;

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
            return View(await _context.Games.ToListAsync());
        }
    }
}