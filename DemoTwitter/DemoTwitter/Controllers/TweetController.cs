using System;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Tweets;
using DemoTwitter.Models;

namespace DemoTwitter.Controllers
{
    public class TweetController : Controller
    {
        ITweetBL tweetBl = new TweetBL();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tweet tweet)
        {
            int userID;
            int.TryParse(Session["UserID"].ToString(), out userID);
            tweet.PostDate = DateTime.Now;
            tweet.UserId = userID;
            tweetBl.Add(tweet);
            return RedirectToAction("Index", "User");
        }
    }
}
