using System;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Tweets;
using DemoTwitter.Models;


namespace DemoTwitter.WEB.Controllers
{
    [System.Web.Mvc.Authorize]
    public class TweetController : Controller
    {
        ITweetBL tweetBl = new TweetBL();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "User");
        }
        [System.Web.Mvc.HttpPost]
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

        public ActionResult AllTweets()
        {
            return PartialView(tweetBl.GetAll());
        }
    }
}
