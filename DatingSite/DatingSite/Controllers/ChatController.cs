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
            //var userRepo = new UserRepository(_context);
            //var userId = userRepo.getUserIdByMail(User.Identity.Name);
            //var viewModel = from users in _context.Users
            //                join friends in _context.Friends on users.UserId equals friends.ReceiverId
            //                where friends.SenderId == userId
            //                orderby users.FirstName
            //                select new FriendViewModel { UserId = users.UserId, FirstName = users.FirstName, LastName = users.LastName, Online = users.Online };

            return View();
        }
     
    }
}