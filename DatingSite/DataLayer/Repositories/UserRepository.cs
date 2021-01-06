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
        private GameRepository gamesRepository;
        private GenreRepository genreRepository;
        private PlatformRepository platformRepository;
        private NationalityRepository nationalityRepository;
        private PersonalityRepository personalityRepository;

        public UserRepository(DatingSiteContext context)
        {
            _context = context;
            gamesRepository = new GameRepository(_context);
            genreRepository = new GenreRepository(_context);
            platformRepository = new PlatformRepository(_context);
            nationalityRepository = new NationalityRepository(_context);
            personalityRepository = new PersonalityRepository(_context);
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public int getUserIdByMail(string mail)
        {
            return _context.Users.FirstOrDefault(x => x.Mail.Equals(mail)).UserId;
        }

        public List<string> getUserGamesById(int userId)
        {
            var list = new List<string>();
            var games = gamesRepository.GetGames();
            var user = _context.Users.FirstOrDefault(x => x.UserId.Equals(userId));
            _context.Entry(user).Collection(x => x.Games).Load();
            _context.Entry(user).Collection(y => y.Genres).Load();
            foreach (var game in user.Games)
            {
                list.Add(game.Name);
            }
            foreach (var genre in user.Genres)
            {
                list.Add(genre.Name);
            }
            //foreach (var d in games)
            //{
            //    _context.Entry(d).Collection(x => x.Users).Load();
            //    foreach (User c in d.Users)
            //    {
            //        list.Add(d.Name + " + " + c.FirstName);
            //    }
            //}
            return list;
        }

        public IOrderedEnumerable<(User, List<Game>, List<Genre>, List<Platform>, int?)> getUserGamesGenresPlatformsScore(string mail)
        {
            var list = new List<(User, List<Game>, List<Genre>, List<Platform>, int?)>();
            var users = _context.Users.ToList();
            ScoreCalculator scoreCalculator = new ScoreCalculator(_context);

            int i = 0;
            foreach (var user in users)
            {
                int? score = null;
                if (!user.Mail.Equals(mail))
                {
                    score = scoreCalculator.GetTotalScoreAllUsersPerUser(mail)[user.UserId];
                }
                list.Add((user, new List<Game>(), new List<Genre>(), new List<Platform>(), score));

                _context.Entry(user).Collection(x => x.Games).Load();
                _context.Entry(user).Collection(x => x.Genres).Load();
                _context.Entry(user).Collection(x => x.Platforms).Load();
                _context.Entry(user).Collection(x => x.Visitors).Load();
                foreach (var game in user.Games)
                {
                    list[i].Item2.Add(game);
                }
                foreach (var genre in user.Genres)
                {
                    list[i].Item3.Add(genre);
                }
                foreach (var platform in user.Platforms)
                {
                    list[i].Item4.Add(platform);
                }
                i++;
            }
            return list.OrderByDescending(o => o.Item5);
        }

        public List<Visit> GetUserVisitorsByMail(string mail)
        {
            var list = new List<Visit>();
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                _context.Entry(user).Collection(x => x.Visitors).Load();
                foreach (Visit v in user.Visitors)
                {
                    if (user.Mail.Equals(mail))
                    {
                        list.Add(v);
                    }
                }
            }
            return list;
        }

        public List<Game> GetUserGamesByMail(string mail)
        {
            var list = new List<Game>();
            var games = gamesRepository.GetGames();
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
            var genres = genreRepository.GetGenres();
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
            var platforms = platformRepository.GetPlatforms();
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
            var games = gamesRepository.GetGames();
            foreach (var d in selectedGames)
            {
                foreach (var e in games)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Games.Add(e);
                        var y = gamesRepository.GetGames().FirstOrDefault<Game>(y => y.Name.Equals(e.Name));
                        y.Users.Add(x);
                    }
                }
            }
            _context.SaveChanges();
        }

        public void RemoveUserGames(string mail, string[] selectedGames)
        {
            var games = gamesRepository.GetGames();
            foreach (var d in selectedGames)
            {
                foreach (var e in games)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Games.Remove(e);
                        var y = gamesRepository.GetGames().FirstOrDefault<Game>(y => y.Name.Equals(e.Name));
                        y.Users.Remove(x);
                    }
                }
            }
            _context.SaveChanges();

        }

        public void SetUserGenres(string mail, string[] selectedGenres)
        {
            var genres = genreRepository.GetGenres();
            foreach (var d in selectedGenres)
            {
                foreach (var e in genres)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Genres.Add(e);
                        var y = genreRepository.GetGenres().FirstOrDefault<Genre>(y => y.Name.Equals(e.Name));
                        y.Users.Add(x);
                    }
                }
            }
            _context.SaveChanges();
        }

        public void RemoveUserGenres(string mail, string[] selectedGenre)
        {
            var genre = genreRepository.GetGenres();
            foreach (var d in selectedGenre)
            {
                foreach (var e in genre)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Genres.Remove(e);
                        var y = genreRepository.GetGenres().FirstOrDefault<Genre>(y => y.Name.Equals(e.Name));
                        y.Users.Remove(x);
                    }
                }
            }
            _context.SaveChanges();

        }

        public void SetUserPlatforms(string mail, string[] selectedPlatforms)
        {
            var platforms = platformRepository.GetPlatforms();
            foreach (var d in selectedPlatforms)
            {
                foreach (var e in platforms)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Platforms.Add(e);
                        var y = platformRepository.GetPlatforms().FirstOrDefault<Platform>(y => y.Name.Equals(e.Name));
                        y.Users.Add(x);
                    }
                }
            }
            _context.SaveChanges();
        }

        public void RemoveUserPlatforms(string mail, string[] selectedPlatform)
        {
            var platforms = platformRepository.GetPlatforms();
            foreach (var d in selectedPlatform)
            {
                foreach (var e in platforms)
                {
                    if (e.Name.Equals(d))
                    {
                        var x = _context.Users.FirstOrDefault<User>(x => x.Mail.Equals(mail));
                        x.Platforms.Remove(e);
                        var y = platformRepository.GetPlatforms().FirstOrDefault<Platform>(y => y.Name.Equals(e.Name));
                        y.Users.Remove(x);
                    }
                }
            }
            _context.SaveChanges();

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
            _context.SaveChanges();
        }

        //public void EditUserByMail(string mail)

        public void EditUserByMail()
        {
            //getUserByMail(mail);
            var x = _context.Users.Find(getUserByMail("lukas.brolin@dating.com").UserId);
            x.FirstName = "Lukas";
            x.Mail = "lukas.brolin@dating.se";
            _context.SaveChanges();

        }

        public User getUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId.Equals(id));
        }

        public User getUserByMail(string mail)
        {
            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));
            _context.Entry(user).Collection(x => x.Games).Load();
            _context.Entry(user).Collection(x => x.Genres).Load();
            _context.Entry(user).Collection(x => x.Platforms).Load();
            user.Nationality = nationalityRepository.GetNationalityById(user.NationalityId);
            user.Personality = personalityRepository.GetPersonalityById(user.PersonalityId);
            _context.Entry(user).Collection(x => x.Platforms).Load();

            return user;
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