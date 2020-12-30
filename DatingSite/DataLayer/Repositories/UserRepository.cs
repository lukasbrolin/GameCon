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

        //public List<string> getUserGamesAll()
        //{
        //    var list = new List<string>();
        //    var games = _context.Games.ToList();
        //    foreach (var d in games)
        //    {
        //        _context.Entry(d).Collection(x => x.Users).Load();
        //        foreach (User c in d.Users)
        //        {
        //            list.Add(d.Name + " + " + c.FirstName);
        //        }
        //    }
        //    return list;
        //}


        public List<Game> GetUserGamesByMail(string mail)
        {
            var list = new List<Game>();
            var games = _context.Games.ToList();
            foreach (var d in games)
            {
                _context.Entry(d).Collection(x => x.Users).Load();
                foreach (User c in d.Users)
                {
                    if (c.Mail.Equals(mail))
                        list.Add(d);
                }
            }
            return list;
        }

        public List<Genre> GetUserGenresByMail(string mail)
        {
            var list = new List<Genre>();
            var genres = _context.Genres.ToList();
            foreach (var d in genres)
            {
                _context.Entry(d).Collection(x => x.Users).Load();
                foreach (User c in d.Users)
                {
                    if (c.Mail.Equals(mail))
                        list.Add(d);
                }
            }
            return list;
        }

        public List<Platform> GetUserPlatformsByMail(string mail)
        {
            var list = new List<Platform>();
            var platforms = _context.Platforms.ToList();
            foreach (var d in platforms)
            {
                _context.Entry(d).Collection(x => x.Users).Load();
                foreach (User c in d.Users)
                {
                    if (c.Mail.Equals(mail))
                        list.Add(d);
                }
            }
            return list;
        }

        public void SetUserGames(string mail, string[] selectedGames)
        {
            var games = _context.Games.ToList();
            foreach (var d in selectedGames)
            {
                foreach (var e in games)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Games.Add(e);
                        var y = _context.Games.FirstOrDefault<Game>(y => y.Name.Equals(e.Name));
                        y.Users.Add(x);
                    }
                }
            }
            _context.SaveChanges();
        }

        public void SetUserGenres(string mail, string[] selectedGenres)
        {
            var genres = _context.Genres.ToList();
            foreach (var d in selectedGenres)
            {
                foreach (var e in genres)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Genres.Add(e);
                        var y = _context.Genres.FirstOrDefault<Genre>(y => y.Name.Equals(e.Name));
                        y.Users.Add(x);
                    }
                }
            }
            _context.SaveChanges();
        }

        public void SetUserPlatforms(string mail, string[] selectedPlatforms)
        {
            var platforms = _context.Platforms.ToList();
            foreach (var d in selectedPlatforms)
            {
                foreach (var e in platforms)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Platforms.Add(e);
                        var y = _context.Platforms.FirstOrDefault<Platform>(y => y.Name.Equals(e.Name));
                        y.Users.Add(x);
                    }
                }
            }
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

        public User getUserByMail(string mail)
        {
            return _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));
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