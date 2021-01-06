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
        private readonly DatingSiteContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(DatingSiteContext context, UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Users.ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mail,Age,Gender,PreferedLanguage,Online,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mail,Age,Gender,PreferedLanguage,Online,Active")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        public IActionResult HideOrUnhide()
        {
            var repo = new UserRepository(_context);
            var userId = repo.getUserIdByMail(User.Identity.Name);
            var user = _context.Users.Find(userId);
            if (user.IsHidden)
            {
                user.IsHidden = false;
            }
            else
            {
                user.IsHidden = true;
            }
            _context.SaveChanges();
            return Redirect("/Identity/Account/Manage");
        }

        public IActionResult InactivateOrActivate()
        {
            var repo = new UserRepository(_context);
            var userId = repo.getUserIdByMail(User.Identity.Name);
            var user = _context.Users.Find(userId);
            if (user.Active)
            {
                user.Active = false;
            }
            else
            {
                user.Active = true;
            }
            _context.SaveChanges();
            return Redirect("/Identity/Account/Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMail(string usermail)
        {
            var userRepository = new UserRepository(_context);
            userRepository.EditUserByMail(User.Identity.Name,usermail);
            var appList = _userManager.Users.ToList();
            var identityUser = appList.FirstOrDefault(x => x.UserName.Equals(User.Identity.Name));
            var setEmailResult = await _userManager.SetEmailAsync(identityUser, usermail);
            var setUserNameResult = await _userManager.SetUserNameAsync(identityUser, usermail);

            //await _userManager.ChangePasswordAsync(identityUser, "123Asd!", "123Abc!");

            await _signInManager.RefreshSignInAsync(identityUser);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var appList = _userManager.Users.ToList();
            var identityUser = appList.FirstOrDefault(x => x.UserName.Equals(User.Identity.Name));
            await _userManager.ChangePasswordAsync(identityUser, oldPassword, newPassword);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}