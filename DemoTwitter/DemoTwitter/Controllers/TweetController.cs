using System;
using System.Linq;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Tweets;
using DemoTwitter.Models;

namespace DemoTwitter.WEB.Controllers
{
    public class TweetController : Controller
    {
        ITweetBL tweetBl = new TweetBL();

        [HttpPost]
        public ActionResult Index(Tweet tweet)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Tweet");
            int userID;
            int.TryParse(Session["UserID"].ToString(), out userID);
            tweet.PostDate = DateTime.Today;
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
