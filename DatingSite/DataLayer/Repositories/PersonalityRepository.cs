using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class PersonalityRepository
    {
        private readonly DatingSiteContext _context;

        public PersonalityRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Personality> GetPersonalities()
        {
            return _context.Personalities.ToList();
        }

        public void AddPersonality(Personality personality)
        {
            _context.Personalities.Add(personality);
        }

        public Personality GetPersonalityById(int id)
        {
            return _context.Personalities.FirstOrDefault(x => x.PersonalityId.Equals(id));
        }

        public int GetPersonalityIdByName(string name)
        {
            return _context.Personalities.FirstOrDefault(i => i.Description == name).PersonalityId;
        }
    }
}