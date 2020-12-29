using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class GenreRepository
    {
        private readonly DatingSiteContext _context;

        public GenreRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public IList<String> GetGenreNames()
        {
            return _context.Genres.Cast<Genre>().Select(x => x.Name).ToList();

        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(x => x.GenreId.Equals(id));
        }
    }
}