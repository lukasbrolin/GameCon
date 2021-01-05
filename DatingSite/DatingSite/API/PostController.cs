using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Models;

namespace DatingSite.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DatingSiteContext _context;

        public PostController(DatingSiteContext context)
        {
            _context = context;
        }

        [Route("post")]
        public void post(string reciever, string content)
        {

            var userRepository = new UserRepository(_context);
            var postRepository = new PostRepository(_context);
            var sender = userRepository.getUserByMail(User.Identity.Name);
            var UserReciever = userRepository.getUserByMail(reciever);
            postRepository.CreatePost(UserReciever, sender, content);
        }

        //[Route("posts")]
        //[HttpPost]
        //public List<object> Posts(List<string> mail)
        //{

        //    var userRep = new UserRepository(_context);
        //    var postsRep = new PostRepository(_context);
        //    var user = userRep.getUserByMail(mail[0]);
        //    List<Post> data = postsRep.GetPostsByMailOrderedByLatestDate(user.Mail);
        //    List<object> returnData = new List<object>();
        //    //List<object> returnData = new List<object>();
        //    foreach (var post in data)
        //    {
        //        returnData.Add(new
        //        {
        //            Sender = userRep.getUserById(post.SenderId).NickName,
        //            Content = post.Content,
        //            Date = post.TimeStamp
        //        });
        //    }
        //    return returnData;
        //}

        //[Route("detelepost")]
        //public void DeletePost(string mail)
        //{
        //    var postRepository = new PostRepository(_context);
        //    //postRepository.DeletePost();
        //}


    }

}
