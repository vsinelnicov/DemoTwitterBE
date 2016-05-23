﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;
using PagedList;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        private ITweetBL tweetBl;
        private IUserBL userBl;

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
            tweetBl.Add(tweet);
            return RedirectToAction("Index", "User");
        }
        public ActionResult Remove(Tweet tweet)
        {
            tweetBl.Remove(tweet);
            return RedirectToAction("Index", "User");
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
            tweetBl.Update(tweet);
            return RedirectToAction("Index", "User");
        }
    }
}