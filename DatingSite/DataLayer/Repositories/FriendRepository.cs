using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class FriendRepository
    {
        private readonly DatingSiteContext _context;

        public FriendRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Friend> GetFriends()
        {
            return _context.Friends.ToList();
        }

        public void AddFriend(Friend friend)
        {
            _context.Friends.Add(friend);
        }

        public Friend GetFriendById(int id)
        {
            return _context.Friends.FirstOrDefault(x => x.FriendId.Equals(id));
        }

        public List<int> GetFriendsIdByUserId(int id)
        {
            return _context.Friends.Where(y => y.SenderId.Equals(id)).Select(x => x.ReceiverId).ToList();
        }
    }
}