using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class VisitRepository
    {
        private DatingSiteContext _context;
        private UserRepository userRepository;

        public VisitRepository(DatingSiteContext context)
        {
            _context = context;
            userRepository = new UserRepository(_context);
        }

        public List<Visit> GetVisits()
        {
            return _context.Visits.ToList();
        }

        public Visit CreateVisit(User reciever, User sender, DateTime date)
        {
            Visit visit = (new Visit
            {
                Receiver = reciever,
                ReceiverId = reciever.UserId,
                Sender = sender,
                SenderId = sender.UserId,
                TimeStamp = date
            });
            return visit;
        }

        public void AddVisits(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
        }

        public Visit GetVisitById(int id)
        {
            return _context.Visits.FirstOrDefault(x => x.VisitId.Equals(id));
        }

        public List<User> GetVisitorsByMailOrderedByLatestDate(string mail)
        {
            var list = _context.Visits.OrderByDescending(z => z.TimeStamp)
                .Where(x => x.ReceiverId.Equals(userRepository.getUserByMail(mail).UserId) && x.Sender.Active == true)
                .Select(y => y.SenderId).ToList();
            var userList = new List<User>();
            foreach (var id in list)
            {
                userList.Add(userRepository.getUserById(id));
            }
            System.Console.WriteLine(userList);
            return userList;
        }

        public List<User> GetLatestFiveVisitorsByMail(string mail)
        {
            return GetVisitorsByMailOrderedByLatestDate(mail).Distinct().Take(5).ToList();
        }
    }
}