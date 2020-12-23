using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class StatusRepository
    {
        private readonly DatingSiteContext _context;

        public StatusRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        public void AddStatus(Status status)
        {
            _context.Statuses.Add(status);
        }

        public Status GetStatusById(int id)
        {
            return _context.Statuses.FirstOrDefault(x => x.StatusId.Equals(id));
        }

    }
}