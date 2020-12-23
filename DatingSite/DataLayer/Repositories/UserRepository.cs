using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    internal class UserRepository
    {
        private readonly DatingSiteContext _context;

        public UserRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public List<User> GetUserByName(string search)
        {
            var users = GetUsers();
            var match = new List<User>();
            foreach (var user in users)
            {
                string fullName = user.FirstName + user.LastName;
                if (search.ToLower().Contains(fullName.ToLower()))
                {
                    match.Add(user);
                }
            }
            return match;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public User getUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId.Equals(id));
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(user => e.UserId == id);
        }
    }
}