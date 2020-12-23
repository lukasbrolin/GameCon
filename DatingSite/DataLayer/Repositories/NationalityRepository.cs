using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class NationalityRepository
    {
        private readonly DatingSiteContext _context;

        public NationalityRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Nationality> GetNationalities()
        {
            return _context.Nationalities.ToList();
        }

        public void AddNationality(Nationality nationality)
        {
            _context.Nationalities.Add(nationality);
        }

        public Nationality GetNationalityById(int id)
        {
            return _context.Nationalities.FirstOrDefault(x => x.NationalityId.Equals(id));
        }

    }
}