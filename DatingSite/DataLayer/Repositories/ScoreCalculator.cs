﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ScoreCalculator
    {
        private readonly DatingSiteContext _context;
        private UserRepository _userRepository;

        public ScoreCalculator(DatingSiteContext context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
        }
        public User BestMatch(string mail)
        {
            return null;
        }

        public Dictionary<int,int> GetGameScoreAllUsersPerUser(string mail)
        {
            Dictionary<int, int> ScoreList = new Dictionary<int, int>();
            List<Game> userGames = _userRepository.GetUserGamesByMail(mail);
            var Users = _context.Users.ToList();
            
            foreach(var user in Users)
            {
                if (user.Mail.Equals(mail))
                {
                    continue;
                }
                int i = 0;
                _context.Entry(user).Collection(x => x.Games).Load();
                foreach(Game game in user.Games)
                {
                    foreach(Game userGame in userGames)
                    {
                        if (game.GameId.Equals(userGame.GameId))
                        {
                            i++;
                        }
                    }
                }
                ScoreList.Add(user.UserId, i);
            }
            foreach(KeyValuePair<int,int> kvp in ScoreList)
            {
                Console.WriteLine("User: " + kvp.Key + " has Score: " + kvp.Value);
            }
            return ScoreList;
        }

        //public int GetGameScoreUserPerUser(string mail, int id)
        //{
        //    List<Game> userGames = _userRepository.GetUserGamesByMail(mail);
        //    List<Game> userGames = _userRepository.GetUserGamesByMail(mail);


        //}

        public Dictionary<int, int> GetGenreScoreAllUsersPerUser(string mail)
        {
            Dictionary<int, int> ScoreList = new Dictionary<int, int>();
            List<Genre> userGenres = _userRepository.GetUserGenresByMail(mail);
            var Users = _context.Users.ToList();

            foreach (var user in Users)
            {
                if (user.Mail.Equals(mail))
                {
                    continue;
                }
                int i = 0;
                _context.Entry(user).Collection(x => x.Genres).Load();
                foreach (Genre genre in user.Genres)
                {
                    foreach (Genre userGenre in userGenres)
                    {
                        if (genre.GenreId.Equals(userGenre.GenreId))
                        {
                            i++;
                        }
                    }
                }
                ScoreList.Add(user.UserId, i);
            }
            foreach (KeyValuePair<int, int> kvp in ScoreList)
            {
                Console.WriteLine("User: " + kvp.Key + " has Score: " + kvp.Value);
            }
            return ScoreList;
        }

        public Dictionary<int, int> GetPlatformScoreAllUsersPerUser(string mail)
        {
            Dictionary<int, int> ScoreList = new Dictionary<int, int>();
            List<Platform> userPlatforms = _userRepository.GetUserPlatformsByMail(mail);
            var Users = _context.Users.ToList();

            foreach (var user in Users)
            {
                if (user.Mail.Equals(mail))
                {
                    continue;
                }
                int i = 0;
                _context.Entry(user).Collection(x => x.Platforms).Load();
                foreach (Platform platform in user.Platforms)
                {
                    foreach (Platform userPlatform in userPlatforms)
                    {
                        if (platform.PlatformId.Equals(userPlatform.PlatformId))
                        {
                            i++;
                        }
                    }
                }
                ScoreList.Add(user.UserId, i);
            }
            foreach (KeyValuePair<int, int> kvp in ScoreList)
            {
                Console.WriteLine("User: " + kvp.Key + " has Score: " + kvp.Value);
            }
            return ScoreList;
        }

        public Dictionary<int, int> GetPersonalityScoreAllUsersPerUser(string mail)
        {
            Dictionary<int, int> ScoreList = new Dictionary<int, int>();
            List<User> Users = _userRepository.GetUsers();
            User thisUser = _userRepository.getUserByMail(mail);


            foreach (var user in Users)
            {
                int i = 0;
                if (!user.PersonalityId.Equals(null))
                {
                    if (user.Mail.Equals(mail))
                    {
                        continue;
                    }
                    if (user.PersonalityId.Equals(thisUser.PersonalityId))
                    {
                        i++;
                    }
                    ScoreList.Add(user.UserId, i);
                }
                else
                {
                    ScoreList.Add(user.UserId, i);
                }
                
                
            }
            
            return ScoreList;
        }

        public Dictionary<int, int> GetNationalityScoreAllUsersPerUser(string mail)
        {
            Dictionary<int, int> ScoreList = new Dictionary<int, int>();
            List<User> Users = _userRepository.GetUsers();
            User thisUser = _userRepository.getUserByMail(mail);


            foreach (var user in Users)
            {
                int i = 0;
                if (user.Mail.Equals(mail))
                {
                    continue;
                }
                if (user.NationalityId.Equals(thisUser.NationalityId))
                {
                    i++;
                }
                ScoreList.Add(user.UserId, i);
            }

            return ScoreList;
        }

        public Dictionary<int,int> GetTotalScoreAllUsersPerUser(string mail)
        {
            Dictionary<int, int> TotalScore = new Dictionary<int, int>();
            foreach (KeyValuePair<int,int> kvp in GetGameScoreAllUsersPerUser(mail))
            {
                int score = 0;
                int genreScore;
                GetGenreScoreAllUsersPerUser(mail).TryGetValue(kvp.Key, out genreScore);
                int platformScore;
                GetPlatformScoreAllUsersPerUser(mail).TryGetValue(kvp.Key, out platformScore);
                int personalityScore;
                GetPersonalityScoreAllUsersPerUser(mail).TryGetValue(kvp.Key, out personalityScore);
                int nationalityScore;
                GetNationalityScoreAllUsersPerUser(mail).TryGetValue(kvp.Key, out nationalityScore);
                score = (kvp.Value + genreScore + platformScore + personalityScore + nationalityScore);
                TotalScore.Add(kvp.Key, score);
            }
            foreach (KeyValuePair<int, int> kvp in TotalScore)
            {
                Console.WriteLine("User: " + kvp.Key + " has Score: " + kvp.Value);
            }
            return TotalScore;
        }


    }

    
}
