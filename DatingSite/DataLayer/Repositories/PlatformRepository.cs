using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class PlatformRepository
    {
        private readonly DatingSiteContext _context;

        public PlatformRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public IList<string> GetPlatformNames()
        {
            return _context.Platforms.Cast<Platform>().Select(x => x.Name).ToList();

        }

        public void AddPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(x => x.PlatformId.Equals(id));
        }

    }
}