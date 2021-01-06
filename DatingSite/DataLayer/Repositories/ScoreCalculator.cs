using DataLayer.Models;
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
            var Users = _userRepository.GetUsers();
            
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
            return ScoreList;
        }

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

        public Dictionary<int,int> GetAgeScoreAllUsersPerUser(string mail)
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
                if(user.Age < (user.Age + 2) && user.Age > (user.Age -2)){
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
                int ageScore;
                GetAgeScoreAllUsersPerUser(mail).TryGetValue(kvp.Key, out ageScore);
                score = (kvp.Value + genreScore + platformScore + personalityScore + nationalityScore + ageScore);
                if(score <= 10)
                {
                    TotalScore.Add(kvp.Key, score);
                }
                else
                {
                    TotalScore.Add(kvp.Key, 10);
                }
                
            }
            return TotalScore;
        }

        public string ScoreDescription(int? score)
        {
            switch (score)
            {
                case 0:
                case 1:
                case 2:
                    return "It couldnt be a worse match..";
                    break;
                case 3:
                case 4:
                case 5:
                    return "Well, it could be a worse match..";
                    break;
                case 6:
                case 7:
                case 8:
                    return "This is a good match!!";
                    break;
                case 9:
                case 10:
                    return "YOU ARE SOULMATES AND HAVE TO PLAY SOME GAMES TOGHETHER";
                    break;

                default:
                    return null;
            }
        }


    }

    
}
