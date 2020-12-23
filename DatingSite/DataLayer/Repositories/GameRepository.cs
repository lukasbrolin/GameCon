﻿using DataLayer.Models;
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

        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
        }

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(x => x.GameId.Equals(id));
        }
    }
}