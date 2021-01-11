using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class PersonalityRepository
    {
        private readonly DatingSiteContext _context;
        private GameRepository gameRepository;

        public PersonalityRepository(DatingSiteContext context)
        {
            _context = context;
            gameRepository = new GameRepository(_context);
        }
        
        //Get all personalities to list
        public List<Personality> GetPersonalities()
        {
            return _context.Personalities.ToList();
        }

        //Add new personality to Database
        public void AddPersonality(Personality personality)
        {
            _context.Personalities.Add(personality);
        }

        //Get Personality by Id
        public Personality GetPersonalityById(int id)
        {
            return _context.Personalities.FirstOrDefault(x => x.PersonalityId.Equals(id));
        }

        //Get personality Id by name
        public int GetPersonalityIdByName(string name)
        {
            return _context.Personalities.FirstOrDefault(i => i.Description == name).PersonalityId;
        }
    }
}