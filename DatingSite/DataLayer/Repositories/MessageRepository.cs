using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class MessageRepository
    {
        private readonly DatingSiteContext _context;

        public MessageRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public Message GetMessageById(int id)
        {
            return _context.Messages.FirstOrDefault(x => x.MessageId.Equals(id));
        }

    }
}