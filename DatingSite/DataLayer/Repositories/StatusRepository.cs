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

        //Get all statuses
        public List<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        //Add new status to database
        public void AddStatus(Status status)
        {
            _context.Statuses.Add(status);
        }

        //Get status by Id
        public Status GetStatusById(int id)
        {
            return _context.Statuses.FirstOrDefault(x => x.StatusId.Equals(id));
        }

    }
}