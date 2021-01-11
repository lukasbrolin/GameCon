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

        //displays a view of your friends. uses include to follow the navigation properties for the tables to display more information.
        //only displays friends that are active.
        public async Task<IActionResult> Index()
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //displays view for editing a friends category
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for handling the update of a friends category.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendId,SenderId,ReceiverId,CategoryId,StatusId")] Friend friend)
        {
            try
            {
                if (id != friend.FriendId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _context.Friends.Attach(friend);
                    _context.Entry(friend).Property(c => c.CategoryId).IsModified = true;
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", friend.CategoryId);
                return View(friend);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for deleting a friend from your friendslist.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //finds the user and removes them.
            try
            {
                var friend = await _context.Friends.FindAsync(id);
                _context.Friends.Remove(friend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //check if a friend exists in the db.
        private bool FriendExists(int id)
        {
            try
            {
                return _context.Friends.Any(e => e.ReceiverId == id);
            }
            catch (Exception e)
            {
                RedirectToAction("Index", "Error", new { exception = e });
                return false;
            }
        }

        //method for handling the sending of a friend request. the receiving users gets a notification from SignalR.
        //the receiving user needs to accept the request in order to appear for the sending user.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FriendRequest(int receiverId, int senderId)
        {
            try
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for handling the answer of a friend request from the receiver.
        //two records is creating in the database connecting the two users. the sender gets the receing users in their friendslist.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AnswerRequest(int receiverId, int senderId)
        {
            try
            {
                var requestingFriend = _context.Friends.First(f => f.SenderId == senderId);
                requestingFriend.StatusId = 2;
                var friend = new Friend { SenderId = receiverId, ReceiverId = senderId, CategoryId = 1, StatusId = 2 };
                _context.Friends.Add(friend);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for handling the deny of a friend request from the receiver. the request is aborted and the pending request is removed from the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DenyRequest(int friendId)
        {
            try
            {
                var friend = _context.Friends.Find(friendId);
                _context.Friends.Remove(friend);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }

        //method for handling the removeal of a friend from the friendlist. the two correspoding rows in the friends table connecting the users is removed.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFriend(int senderId, int receiverId)
        {
            try
            {
                var sender = _context.Friends.First(f => f.SenderId == senderId && f.ReceiverId == receiverId);
                var receiver = _context.Friends.First(f => f.SenderId == receiverId && f.ReceiverId == senderId);
                _context.Friends.Remove(sender);
                _context.Friends.Remove(receiver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
        }
    }
}