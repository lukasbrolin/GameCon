using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Models;
using DatingSite.Data;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DatingSite.Controllers
{
    public class UsersController : Controller
    {
        private UserRepository _userRepository;
        private readonly DatingSiteContext _context;

        public UsersController(DatingSiteContext context)
        {
            _userRepository = new UserRepository(_context);
            _context = context;
        }

        //hides or unhide the account in settings. a hidden account wont show up in search for other users. 
        public IActionResult HideOrUnhide()
        {
            try
            {
                var userId = _userRepository.getUserIdByMail(User.Identity.Name);
                if (_userRepository.GetHidden(userId))
                {
                    _userRepository.ShowUser(userId);
                }
                else
                {
                    _userRepository.HideUser(userId);
                }
                return Redirect("/Identity/Account/Manage");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //activate or inactivate the account in settings. an inactivated account wont show up in search, match, or in other users friendlist. 
        public IActionResult InactivateOrActivate()
        {
            try
            {
                var userId = _userRepository.getUserIdByMail(User.Identity.Name);
                if (_userRepository.GetActive(userId))
                {
                    _userRepository.InactivateUser(userId);
                }
                else
                {
                    _userRepository.ActivateUser(userId);
                }
                return Redirect("/Identity/Account/Manage");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}