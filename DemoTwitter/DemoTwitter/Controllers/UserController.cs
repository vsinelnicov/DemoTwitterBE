<<<<<<< HEAD
﻿using System.Linq;
=======
﻿using System.Net;
>>>>>>> origin/master
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;

namespace DemoTwitter.WEB.Controllers
{

    public class UserController : Controller
    {
        IUserBL userBl = new UserBL();

<<<<<<< HEAD
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = hashHelper.CalculateMd5(user.Password);
                userBl.Register(user);
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(user);
            }
        }

=======
>>>>>>> origin/master
        public ActionResult ShowAllUsers()
        {
            return View(userBl.GetAll());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
