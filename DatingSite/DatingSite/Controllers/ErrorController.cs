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
        //Return view with Error-screen + exception
        public ActionResult Index(ErrorViewModel model, string exception)
        {
            Debug.WriteLine(exception);
            model.SiteMessage = "Sorry, something went wrong. Derp.";
            model.RequestId = exception;
            return View(model);
        }
    }
}