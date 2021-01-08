using DatingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(ErrorViewModel model, Exception exception)
        {
            Debug.WriteLine(exception.Message);
            model.SiteMessage = "Sorry, something went wrong. Derp.";
            model.RequestId =  exception.Message;
            return View(model);
        }
    }
}
