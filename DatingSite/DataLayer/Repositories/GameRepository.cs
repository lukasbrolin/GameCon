using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class GameRepository
    {
        private readonly DatingSiteContext _context;

        public GameRepository(DatingSiteContext context)
        {
            _context = context;
        }

        //Get all games
        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        //Get all game names
        public IList<String> GetGamesNames()
        {
            return _context.Games.Cast<Game>().Select(x => x.Name).ToList();
        }

        //Add new game to database
        public void AddGame(Game game)
        {
            _context.Games.Add(game);
        }

        //Get game by Id
        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(x => x.GameId.Equals(id));
        }

        //Collect games to list by selected games
        public List<Game> GetGamesByNames(string[] gameNames)
        {
            var gameList = new List<Game>();
            foreach (var i in gameNames)
            {
                gameList.Add(_context.Games.FirstOrDefault(x => x.Name.Equals(i)));
            }

            return gameList;
        }
    }
}