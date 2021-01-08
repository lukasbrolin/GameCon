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
        private UserRepository _userRepository;

        public UsersController(DatingSiteContext context, UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = usermanager;
            _signInManager = signInManager;
            _userRepository = new UserRepository(_context);
        }

        public UsersController(DatingSiteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _context.Users.ToListAsync();
                return View(list);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        public IActionResult Create()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mail,Age,Gender,PreferedLanguage,Online,Active")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mail,Age,Gender,PreferedLanguage,Online,Active")] User user)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }

        }

        private bool UserExists(int id)
        {
            try
            {
                return _userRepository.UserExists(id);
            }

            catch (Exception e)
            {
                RedirectToAction("Index", "Error", new { exception = e });
                return false;
            }
        }

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