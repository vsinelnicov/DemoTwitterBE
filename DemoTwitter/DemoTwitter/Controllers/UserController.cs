 ﻿using System.Linq;
 ﻿using System.Net;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;

namespace DemoTwitter.WEB.Controllers
{

    public class UserController : Controller
    {
        IUserBL userBl = new UserBL();

        public ActionResult ShowAllUsers()
        {
            return View(userBl.GetAllUsers());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
