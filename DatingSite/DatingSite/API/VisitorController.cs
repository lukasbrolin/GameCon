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
    public class VisitorController : ControllerBase
    {
        private readonly DatingSiteContext _context;

        public VisitorController(DatingSiteContext context)
        {
            _context = context;
        }

        [Route("visit")]
        [HttpPost]
        public List<object> Visit(List<string> mail)
        {
            
                var userRep = new UserRepository(_context);
                var visitRep = new VisitRepository(_context);
                var user = userRep.getUserByMail(mail[0]);
                List<User> data = visitRep.GetLatestFiveVisitorsByMail(user.Mail);
                List<object> returnData = new List<object>();
                //List<object> returnData = new List<object>();
                foreach (var visit in data)
                {
                    returnData.Add(new
                    {
                        Name = visit.NickName,
                        Img = visit.ImgUrl.Substring(1)
                    });
                }
                return returnData;
            }
            
            
            //if (data != null)
            //{
            //    return data;

            //}
            //else
            //{
            //    //return Content(HttpStatusCode.BadRequest, "No visitors yet.");
            //}
        
    }
    
}
