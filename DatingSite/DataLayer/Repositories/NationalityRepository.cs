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

        //Get all nationalities to list
        public List<Nationality> GetNationalities()
        {
            return _context.Nationalities.ToList();
        }

        //Add new nationality to database
        public void AddNationality(Nationality nationality)
        {
            _context.Nationalities.Add(nationality);
        }

        //Get nationality by Id
        public Nationality GetNationalityById(int id)
        {
            return _context.Nationalities.FirstOrDefault(x => x.NationalityId.Equals(id));
        }

        //Get nationality Id by nationality name
        public int GetNationalityIdByName(string name)
        {
            return _context.Nationalities.FirstOrDefault(i => i.Name == name).NationalityId;
        }

        //Get all nationality names
        public List<string> GetNationalityNames()
        {
            return _context.Nationalities.Cast<Nationality>().Select(x => x.Name).ToList();
        }
    }
}