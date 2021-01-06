﻿using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class SearchController : Controller
    {
        private readonly DatingSiteContext _context;

        public SearchController(DatingSiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Search(string searchString)
        {
            var users = from u in _context.Users
                        .Include(u => u.Nationality)
                        .Where(u => u.IsHidden == false)
                        select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.FirstName.Contains(searchString) || u.LastName.Contains(searchString) || u.NickName.Contains(searchString));
            }

            return View(users.ToList());
        }
    }
}