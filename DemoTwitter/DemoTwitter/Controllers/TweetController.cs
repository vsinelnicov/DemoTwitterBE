using System;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Tweets;
using DemoTwitter.Models;

namespace DemoTwitter.Controllers
{
    public class TweetController : Controller
    {
        ITweetBL tweetBl = new TweetBL();
        //
        // GET: /Tweet/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tweet tweet)
        {
            tweet.PostDate = DateTime.Now;
            //tweet.UserId = 1;
            tweetBl.Add(tweet);
            return RedirectToAction("Index", "User");
        }

    }
}
