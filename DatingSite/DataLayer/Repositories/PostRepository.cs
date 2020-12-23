using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class PostRepository
    {
        private readonly DatingSiteContext _context;

        public PostRepository(DatingSiteContext context)
        {
            _context = context;
        }

        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public List<User> GetPostsByUser(User user)
        {
            return null;
        }
    }
}