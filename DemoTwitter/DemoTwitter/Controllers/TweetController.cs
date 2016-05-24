using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;
using log4net;
using PagedList;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        private ITweetBL tweetBl;
        private IUserBL userBl;
        private static ILog log = LogManager.GetLogger(typeof(TweetController));

        public TweetController(ITweetBL tweetBl, IUserBL userBl)
        {
            this.tweetBl = tweetBl;
            this.userBl = userBl;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        public ActionResult Index(Tweet tweet)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Tweet");
            int userID;
            int.TryParse(Session["UserID"].ToString(), out userID);
            tweet.PostDate = DateTime.Now;
            tweet.UserId = userID;
            if (tweetBl.Add(tweet))
            {
                log.Info("A new Tweet has been added");
                return RedirectToAction("Index", "User");
            }
            else
            {
                log.Error("Tweet could't bee added");
                return RedirectToAction("Error", "Home");
            }

        }
        public ActionResult Remove(int tweetId)
        {
            //if (tweetBl.Remove(tweet))
            //{
            Tweet tweet = new Tweet
            {
                Id = tweetId
            };
            tweetBl.Remove(tweet);
            log.Info("A tweet has been removed");
            return RedirectToAction("Index", "User");
            //}
            //else
            //{
            //    log.Error("Could't remove the tweet");
            //    return RedirectToAction("Error", "Home");
            //}
        }

        public ActionResult All(int? page, User user)
        {
            int userID;
            int.TryParse(Session["UserID"].ToString(), out userID);
            int pageNumber = page ?? 1;
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["tweetPageSize"]);
            return PartialView(tweetBl.GetAll().Where(tweet => tweet.UserId == userID).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult FollowedUsersFeed(int? page)
        {
            int pageNumber = page ?? 1;
            int userID;
            int.TryParse(Session["UserID"].ToString(), out userID);
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["tweetPageSize"]);

            IEnumerable<Tweet> feedTweet = from tweet in tweetBl.GetAll()
                                           join user in userBl.GetAllUsers() on tweet.UserId equals user.Id
                                           where user.Id != null && userBl.IsFollowed(userID, (int)user.Id)
                                           select new Tweet { Id = tweet.Id, UserId = (int)user.Id, PostDate = tweet.PostDate, Text = tweet.Text, Author = user.FirstName + " " + user.LastName };
            return View(feedTweet.OrderByDescending(tweet => tweet.PostDate).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit()
        {
            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        public ActionResult Edit(Tweet tweet)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Tweet");
            int userID;
            int.TryParse(Session["UserID"].ToString(), out userID);
            tweet.PostDate = DateTime.Now;
            tweet.UserId = userID;
            if (tweetBl.Update(tweet))
            {
                log.Info("A tweet has been updated");
                return RedirectToAction("Index", "User");
            }
            else
            {
                log.Error("Tweet could't be updated");
                return RedirectToAction("Error", "Home");
            }
        }
    }
}