using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

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

        //Get all users
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
            throw new System.ArgumentOutOfRangeException();
        }

        //Get users id mail/usernamne
        public int getUserIdByMail(string mail)
        {
            return _context.Users.FirstOrDefault(x => x.Mail.Equals(mail)).UserId;
        }

        //Get user games by user id
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
            return list;
        }

        //Get user game names by user Id
        public List<string> GetUserGameNamesById(int userId)
        {
            var list = new List<string>();
            var games = gamesRepository.GetGames();
            var user = _context.Users.FirstOrDefault(x => x.UserId.Equals(userId));
            _context.Entry(user).Collection(x => x.Games).Load();
            foreach(var game in user.Games)
            {
                list.Add(game.Name);
            }
            return list;

        }

        //Get user platform names by user Id
        public List<string> GetUserPlatformNamesById(int userId)
        {
            var list = new List<string>();
            var platforms = platformRepository.GetPlatforms();
            var user = _context.Users.FirstOrDefault(x => x.UserId.Equals(userId));
            _context.Entry(user).Collection(x => x.Platforms).Load();
            foreach (var platform in user.Platforms)
            {
                list.Add(platform.Name);
            }
            return list;
        }

        //Get user genre names by user Id
        public List<string> GetUserGenreNamesById(int userId)
        {
            var list = new List<string>();
            var genres = genreRepository.GetGenres();
            var user = _context.Users.FirstOrDefault(x => x.UserId.Equals(userId));
            _context.Entry(user).Collection(x => x.Platforms).Load();
            foreach (var platform in user.Platforms)
            {
                list.Add(platform.Name);
            }
            return list;
        }

        //Get user score based on games, genres, platforms by mail/username
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

        //Get users latest visitors by mail/username
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

        //Get user games by mail/username
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

        //Get user genres by mail/username
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

        //Get user platforms by mail/username
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

        //Set new user games by mail/username 
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

        //Remove unselected user games by mail/username
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

        //Set new user genres by mail/username
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

        //Remove unselected user genres by mail/username
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

        //Set new user platforms by mail/username
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

        //Remove unselected user platforms by mail/username
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

        //Get user by search-name
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

        //Add new user to database
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        //Edit user mail/username by current mail/username
        public void EditUserByMail(string oldMail,string newMail)
        {
            //getUserByMail(mail);
            var user = _context.Users.Find(getUserByMail(oldMail).UserId);
            user.Mail = newMail;
            _context.SaveChanges();

        }

        //Get user by Id
        public User getUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId.Equals(id));
        }

        //Get user by mail/username
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

        //Edit user nickname by mail/username
        public void EditUserNickName(string mail, string newNick)
        {
            
            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));

            user.NickName = newNick;

            _context.SaveChanges();
        }

        //Edit user Firstname by mail/username
        public void EditUserFirstName(string mail, string newFirstName)
        {

            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));

            user.FirstName = newFirstName;

            _context.SaveChanges();
        }

        //Edit user lastname by mail/username
        public void EditUserLastName(string mail, string newLastName)
        {

            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));

            user.LastName = newLastName;

            _context.SaveChanges();
        }

        //Edit user age by mail/username
        public void EditUserAge(string mail, int newAge)
        {

            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));

            user.Age = newAge;

            _context.SaveChanges();
        }

        //Edit user gender by mail/username
        public void EditUserGender(string mail, string newGender)
        {

            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));
            user.Gender = newGender;

            _context.SaveChanges();
        }

        //Edit user nationality by mail/username
        public void EditUserNationality(string mail, string newNationality)
        {

            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));
            var nationalityId = nationalityRepository.GetNationalityIdByName(newNationality);
            user.NationalityId = nationalityId;
            _context.SaveChanges();
        }

        //Edit user personality by mail/username
        public void EditUserPersonality(string mail, string newPersonality)
        {
            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));
            var personalityId = personalityRepository.GetPersonalityIdByName(newPersonality);
            user.PersonalityId = personalityId;

            _context.SaveChanges();
        }

        //Edit user profile picture by mail/username
        public void EditUserImgUrl(string mail, string newImgUrl)
        {
            var user = _context.Users.FirstOrDefault(x => x.Mail.Equals(mail));
            user.ImgUrl = newImgUrl;
            _context.SaveChanges();
        }

        //Delete user by Id
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        //Check if user exists by id
        public bool UserExists(int id)
        {
            return _context.Users.Any(user => user.UserId == id);
        }

        //Hide user from search
        public void HideUser(int userId)
        {
            var user = _context.Users.Find(userId);
            user.IsHidden = true;
            _context.SaveChanges();

        }

        //Show user on search
        public void ShowUser(int userId)
        {
            var user = _context.Users.Find(userId);
            user.IsHidden = false;
            _context.SaveChanges();

        }

        //Get hidden users by user Id
        public bool GetHidden(int userId)
        {
            var user = _context.Users.Find(userId);
            return user.IsHidden;
        }

        //Make user account inactive
        public void InactivateUser(int userId)
        {
            var user = _context.Users.Find(userId);
            user.Active = false;
            _context.SaveChanges();
        }

        //Make user account active
        public void ActivateUser(int userId)
        {
            var user = _context.Users.Find(userId);
            user.Active = true;
            _context.SaveChanges();
        }

        //Get active user by Id
        public bool GetActive(int userId)
        {
            var user = _context.Users.Find(userId);
            return user.Active;
        }

        //Get five random users
        public List<User> GetFiveUsers()
        {
            Random r = new Random();
            int[] randomArray = new int[5];
            for(int i = 0; i < randomArray.Length; i++)
            {
                var randomNumber = r.Next(1, GetUsers().Count());
                while (randomArray.Contains(randomNumber))
                {
                    randomNumber = r.Next(1, GetUsers().Count());
                }
                
                randomArray[i] = randomNumber;
            }

            var selectedList = new List<User>();
            var userList = GetUsers();

            foreach (var i in randomArray)
            {
                selectedList.Add(userList[i]);
            }
            
            //var userList = _context.Users.OrderBy(u => r.Next()).Take(5).Where(x => x.Active.Equals(true)).ToList();
            return selectedList;
            
        }

        //Set user Online
        public void IsOnlineTrue(string currentUser)
        {
            var user = getUserByMail(currentUser);
            user.Online = true;
            _context.SaveChanges();
        }

        //Set user Offline
        public void IsOnlineFalse(string currentUser)
        {
            var user = getUserByMail(currentUser);
            user.Online = false;
            _context.SaveChanges();
        }

    }
}