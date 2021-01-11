using DataLayer;
using DataLayer.Models;
using DataLayer.Serialize;
using DataLayer.Repositories;
using DatingSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace DatingSite.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DatingSiteContext _context;

        public ProfileController(DatingSiteContext context)
        {
            _context = context;
        }

        //displays a view for the users profile. fetches preferences and info from db together with user score
        public ActionResult Index(ProfileViewModel model, string profile)
        {
            //fetches everything and saves it in fields
            var userRepository = new UserRepository(_context);
            var nationalityRepository = new NationalityRepository(_context);
            var personalityRepository = new PersonalityRepository(_context);
            var visitRepository = new VisitRepository(_context);
            var postRepository = new PostRepository(_context);
            var scoreCalculator = new ScoreCalculator(_context);
            List<CardViewModel> modelList = new List<CardViewModel>();

            try
            {
                var list = userRepository.GetUsers();
                //loops through each user and returns a list with all the users and their corresponding information
                foreach (var user in userRepository.getUserGamesGenresPlatformsScore(User.Identity.Name))
                {
                    if (user.Item1.NickName.Equals(profile))
                    {
                        var usersVisits = userRepository.GetUserVisitorsByMail(user.Item1.Mail);
                        var userPosts = postRepository.GetPostsByMailOrderedByLatestDate(user.Item1.Mail);

                        user.Item1.Nationality = nationalityRepository.GetNationalityById(user.Item1.NationalityId);
                        user.Item1.Personality = personalityRepository.GetPersonalityById(user.Item1.PersonalityId);
                        model.User = user.Item1;
                        model.Games = user.Item2;
                        model.Genres = user.Item3;
                        model.Platforms = user.Item4;
                        model.Visits = usersVisits;
                        model.Posts = userPosts;

                        if (!user.Item1.Mail.Equals(User.Identity.Name))
                        {
                            visitRepository.AddVisits(visitRepository.CreateVisit(user.Item1, userRepository.getUserByMail(User.Identity.Name), DateTime.Now));
                        }

                        model.Score = user.Item5;
                        model.ScoreDescription = scoreCalculator.ScoreDescription(user.Item5);
                        break;
                    }
                    else if (user.Item1.Mail.Equals(User.Identity.Name))
                    {
                        var usersVisits = userRepository.GetUserVisitorsByMail(User.Identity.Name);
                        var userPosts = postRepository.GetPostsByMailOrderedByLatestDate(user.Item1.Mail);

                        user.Item1.Nationality = nationalityRepository.GetNationalityById(user.Item1.NationalityId);
                        user.Item1.Personality = personalityRepository.GetPersonalityById(user.Item1.PersonalityId);
                        model.User = user.Item1;
                        model.Games = user.Item2;
                        model.Genres = user.Item3;
                        model.Platforms = user.Item4;
                        model.Visits = usersVisits;
                        model.Posts = userPosts;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Error", new { exception = e });
            }

            ViewBag.currentUser = userRepository.getUserIdByMail(User.Identity.Name);
            return View(model);
        }

        //method for saving the users data to an XML file to the desktop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SerializeProfile()
        {
            SerializeProfile userProfile = GetProfileData();
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(userProfile.GetType());
                string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + User.Identity.Name + ".xml";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    serializer.Serialize(memoryStream, userProfile);
                    memoryStream.Position = 0;
                    xmlDocument.Load(memoryStream);
                    xmlDocument.Save(savePath);
                    memoryStream.Close();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { exception = e });
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        //gets the current information and preferences from the db
        private SerializeProfile GetProfileData()
        {
            try
            {
                var userRepository = new UserRepository(_context);
                User userSerialize = userRepository.getUserByMail(User.Identity.Name);
                SerializeProfile serializeProfile = new SerializeProfile()
                {
                    UserId = userSerialize.UserId,
                    NickName = userSerialize.NickName,
                    FirstName = userSerialize.FirstName,
                    LastName = userSerialize.LastName,
                    Mail = userSerialize.Mail,
                    Age = userSerialize.Age,
                    Gender = userSerialize.Gender,
                    ImgUrl = userSerialize.ImgUrl,
                    Nationality = userSerialize.Nationality.Name,
                    Personality = userSerialize.Personality.Description,
                };
                return serializeProfile;
            }
            catch (Exception e)
            {
                RedirectToAction("Index", "Error", new { exception = e });
                return null;
            }
        }

        //publish visitors on your profile page.
        public ActionResult Visitors(VisitorViewModel model)
        {
            return View(model);
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //deletes post from the users profile
        public ActionResult DeletePost(int id)
        {
            var postRepository = new PostRepository(_context);
            postRepository.DeletePost(id);
            return RedirectToAction("Index", "Profile");
        }
    }
}