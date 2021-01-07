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

        // GET: ProfileController
        public ActionResult Index(ProfileViewModel model, string profile)
        {

            var visitorRepository = new VisitRepository(_context);
            var userRepository = new UserRepository(_context);
            var nationalityRepository = new NationalityRepository(_context);
            var personalityRepository = new PersonalityRepository(_context);
            var visitRepository = new VisitRepository(_context);
            var postRepository = new PostRepository(_context);
            var scoreCalculator = new ScoreCalculator(_context);
            var list = userRepository.GetUsers();
            List<CardViewModel> modelList = new List<CardViewModel>();

            var x = userRepository.GetFiveUsers();

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
                    //model.Score = user.Item5;
                    break;
                }
            }

            ViewBag.currentUser = userRepository.getUserIdByMail(User.Identity.Name);
            return View(model);
        }

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
                return null;
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        private SerializeProfile GetProfileData()
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

        public ActionResult Visitors(VisitorViewModel model)
        {
            return View(model);
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        public ActionResult DeletePost(int id)
        {
            var postRepository = new PostRepository(_context);
            postRepository.DeletePost(id);
            return RedirectToAction("Index", "Profile");
        }
    }
}