using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class VisitRepository
    {
        private readonly DatingSiteContext _context;

        public VisitRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Visit> GetVisits()
        {
            return _context.Visits.ToList();
        }


        public void AddVisits(Visit visit)
        {
            _context.Visits.Add(visit);
        }

        public Visit GetVisitById(int id)
        {
            return _context.Visits.FirstOrDefault(x => x.VisitId.Equals(id));
        }

    }
}