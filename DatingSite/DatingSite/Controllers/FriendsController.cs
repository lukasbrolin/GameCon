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
    public class FriendsController : Controller
    {
        private readonly DatingSiteContext _context;

        public FriendsController(DatingSiteContext context)
        {
            _context = context;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            var datingSiteContext = _context.Friends.Include(f => f.Category).Include(f => f.Receiver).Include(f => f.Sender).Include(f => f.Status);
            return View(await datingSiteContext.ToListAsync());
        }

        // GET: Friends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .Include(f => f.Category)
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Include(f => f.Status)
                .FirstOrDefaultAsync(m => m.FriendId == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // GET: Friends/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewData["ReceiverId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description");
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendId,SenderId,ReceiverId,CategoryId,StatusId")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", friend.CategoryId);
            ViewData["ReceiverId"] = new SelectList(_context.Users, "UserId", "FirstName", friend.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "FirstName", friend.SenderId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", friend.StatusId);
            return View(friend);
        }

        // GET: Friends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", friend.CategoryId);
            ViewData["ReceiverId"] = new SelectList(_context.Users, "UserId", "FirstName", friend.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "FirstName", friend.SenderId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", friend.StatusId);
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendId,SenderId,ReceiverId,CategoryId,StatusId")] Friend friend)
        {
            if (id != friend.FriendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendExists(friend.FriendId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", friend.CategoryId);
            ViewData["ReceiverId"] = new SelectList(_context.Users, "UserId", "FirstName", friend.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "UserId", "FirstName", friend.SenderId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Description", friend.StatusId);
            return View(friend);
        }

        // GET: Friends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friends
                .Include(f => f.Category)
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Include(f => f.Status)
                .FirstOrDefaultAsync(m => m.FriendId == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friend = await _context.Friends.FindAsync(id);
            _context.Friends.Remove(friend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendExists(int id)
        {
            return _context.Friends.Any(e => e.FriendId == id);
        }
    }
}
