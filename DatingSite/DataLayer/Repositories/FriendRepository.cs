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

        //Get all friends to list
        public List<Friend> GetFriends()
        {
            return _context.Friends.ToList();
        }

        //Get friend Id by mail/usernamne to list
        public List<User> GetFriendsIdByMail(string mail)
        {
            var userRepository = new UserRepository(_context);
            var userIdList = new List<int>();
            userIdList = _context.Friends.Where(x => x.SenderId.Equals(userRepository.getUserIdByMail(mail))).Select(y => y.ReceiverId).ToList();
            var friendList = new List<User>();
            foreach(var user in userIdList)
            {
                friendList.Add(userRepository.getUserById(user));
            }
            return friendList;
        }

        //Add new friend
        public void AddFriend(Friend friend)
        {
            _context.Friends.Add(friend);
        }

        //Get friend by Id
        public Friend GetFriendById(int id)
        {
            return _context.Friends.FirstOrDefault(x => x.FriendId.Equals(id));
        }

        //Get friend Id by Id 
        public List<int> GetFriendsIdByUserId(int id)
        {
            return _context.Friends.Where(y => y.SenderId.Equals(id)).Select(x => x.ReceiverId).ToList();
        }
    }
}