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

        //Get all genres
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        //Get genre names to list
        public IList<String> GetGenreNames()
        {
            return _context.Genres.Cast<Genre>().Select(x => x.Name).ToList();

        }

        //Add new genre to database
        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
        }

        //Get genre by Id
        public Genre GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(x => x.GenreId.Equals(id));
        }

        //Collect genres to list by selected genres
        public List<Genre> GetGenresByNames(string[] genreNames)
        {
            var genreList = new List<Genre>();
            foreach (var i in genreNames)
            {
                genreList.Add(_context.Genres.FirstOrDefault(x => x.Name.Equals(i)));
            }

            return genreList;
        }
    }
}