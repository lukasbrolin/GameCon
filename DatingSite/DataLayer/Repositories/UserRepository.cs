using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class UserRepository
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

        public List<string> getUserGamesAll()
        {
            var list = new List<string>();
            var games = _context.Games.ToList();
            foreach (var d in games)
            {
                _context.Entry(d).Collection(x => x.Users).Load();
                foreach (User c in d.Users)
                {
                    list.Add(d.Name + " + " + c.FirstName);
                }
            }
            return list;
        }

        public void SetUserGames(string mail, string[] selectedGames)
        {
            var userToUpdate = _context.Users.Include(i => i.Games).Where(i => i.Mail == mail).Single();
            var games = _context.Games.ToList();
            foreach (var d in selectedGames)
            {
                foreach(var e in games)
                {
                    if (e.Name.Equals(d))
                    {
                        //foreach(var g in _context.Users.ToList())
                        //{
                        //    g.Games.Add(e);
                        //}
                        var x = _context.Users.Select(x => x).Where(x => x.Mail == mail).ToList();
                        x[0].Games.Add(e);
                        var y = _context.Games.Select(x => x).Where(x => x.Name == e.Name).ToList();
                        y[0].Users.Add(x[0]);
                     
                    }
                }
                //_context
            }
            //UpdateUserGames(selectedGames, userToUpdate);
            _context.SaveChanges();
        }

        //public void UpdateUserGames(string[] selectedGames, User userToUpdate)
        //{
        //    var selectedGamesList = new List<string>(selectedGames);
        //    foreach(var game in _context.Games)
        //    {
        //        if (selectedGamesList.Contains(game.Name))
        //        {
        //            if(!)
        //        }
        //    }
        //}

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
            _context.SaveChanges();
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
            return _context.Users.Any(user => user.UserId == id);
        }
    }
}