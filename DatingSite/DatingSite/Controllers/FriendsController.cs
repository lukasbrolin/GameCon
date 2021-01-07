using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.SignalR;
using DatingSite.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DatingSite.Controllers
{
    public class FriendsController : Controller
    {
        private readonly DatingSiteContext _context;
        private readonly IHubContext<FriendHub> _friendHubContext;

        public FriendsController(DatingSiteContext context, IHubContext<FriendHub> friendHubContext)
        {
            _context = context;
            _friendHubContext = friendHubContext;
        }

        // GET: Friends
        public async Task<IActionResult> Index()
        {
            var userRepo = new UserRepository(_context);
            var userId = userRepo.getUserIdByMail(User.Identity.Name);
            var categoryRepo = new CategoryRepository(_context);

            var datingSiteContext = _context.Friends
                .Include(f => f.Category)
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .Include(f => f.Status)
                .Where(u => u.SenderId == userId && u.Receiver.Active != false);

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
            return View(friend);
        }

        // POST: Friends/Edit/5
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
                    _context.Friends.Attach(friend);
                    _context.Entry(friend).Property(c => c.CategoryId).IsModified = true;
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
            return _context.Friends.Any(e => e.ReceiverId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FriendRequest(int receiverId, int senderId)
        {
            var repo = new UserRepository(_context);
            var addedFriend = repo.getUserById(receiverId);
            var currentUser = User.Identity.Name;

            var friend = new Friend { SenderId = receiverId, ReceiverId = senderId, CategoryId = 1, StatusId = 1 };
            _context.Friends.Add(friend);
            _context.SaveChanges();

            // Refresh the calling page to reflect changes and notify the added user (if connected)
            _friendHubContext.Clients.User(currentUser).SendAsync("refreshUI");
            _friendHubContext.Clients.User(addedFriend.Mail).SendAsync("added", currentUser);

            //Return user to same profile page.
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AnswerRequest(int receiverId, int senderId)
        {
            var requestingFriend = _context.Friends.First(f => f.SenderId == senderId);
            requestingFriend.StatusId = 2;
            var friend = new Friend { SenderId = receiverId, ReceiverId = senderId, CategoryId = 1, StatusId = 2 };

            _context.Friends.Add(friend);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}