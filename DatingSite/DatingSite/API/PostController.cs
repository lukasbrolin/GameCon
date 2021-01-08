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
            try
            {
                var userRepository = new UserRepository(_context);
                var postRepository = new PostRepository(_context);
                var sender = userRepository.getUserByMail(User.Identity.Name);
                var UserReciever = userRepository.getUserByMail(reciever);
                postRepository.CreatePost(UserReciever, sender, content);
            }
            catch (Exception e)
            {
                 RedirectToAction("Index", "Error", new { exception = e });
            }

        }

    }

}
