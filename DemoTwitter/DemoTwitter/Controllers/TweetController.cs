using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Tweets;
using DemoTwitter.Models;
using PagedList;


namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    public class TweetController : Controller
    {
        ITweetBL tweetBl = new TweetBL();

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
        [HttpPost]
        public ActionResult Remove(Tweet tweet)
        {
            tweetBl.Remove(tweet);
            return RedirectToAction("Index", "User");
        }
        public ActionResult Remove()
        {
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
    }
}
