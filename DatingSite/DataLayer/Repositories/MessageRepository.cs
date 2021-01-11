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

        //Get message to list
        public List<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }

        //Add new message
        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        //Get message by user
        public Message GetMessageByUser(User user)
        {
            return _context.Messages.FirstOrDefault(x => x.MessageId.Equals(user));
        }

        //Get messages by Id
        public List<Message> GetMessages(int id)
        {
            return _context.Messages.ToList().Where(u => u.SenderId == id).ToList();
        }
    }
}