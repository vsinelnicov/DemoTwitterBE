using System;
 ﻿using System.Configuration;
 ﻿using System.Web;
 ﻿using System.Web.Mvc;
 ﻿using System.Web.Security;
 ﻿using DemoTwitter.BusinessLayer;
 ﻿using DemoTwitter.Models;
 ﻿using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserBL userBl;

        public UserController(IUserBL userBl)
        {
            this.userBl = userBl;
        }

        public ActionResult All(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            List<User> allUser = userBl.GetAllUsers().ToList();
            List<User> final = new List<User>();

            int Id = (int)Session["UserID"];
            foreach (var currentUser in allUser)
            {
                if (userBl.IsFollowed(Id, currentUser.Id ?? 0))
                {
                    currentUser.IsFollowed = true;
                    final.Add(currentUser);
                }
                else
                {
                    final.Add(currentUser);
                }
            }
            return View(final.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            var urlToRemove = Url.Action("Index", "User");
            if (urlToRemove != null) HttpResponse.RemoveOutputCacheItem(urlToRemove);

            return RedirectToAction("Login", "Home");
        }

        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userBl.Update(user);
                return RedirectToAction("Index", "User");
            }
            return View(user);
        }

<<<<<<< HEAD
        public ActionResult ErrorPage()
        {
            return View();
=======
        public ActionResult Follow(int? followedUserId)
        {
            User follower = new User
            {
                Id = (int?)Session["UserID"]
            };

            if (ModelState.IsValid)
            {
                userBl.Follow(follower.Id ?? 0, followedUserId ?? 0);
                if (follower.Id == 0 || followedUserId == 0)
                {
                    return RedirectToAction("All", "User");
                }
            }
            return RedirectToAction("All", "User");
        }

        public ActionResult UnFollow(int? followedUserId)
        {
            User follower = new User
            {
                Id = (int?)Session["UserID"]
            };

            if (ModelState.IsValid)
            {
                userBl.UnFollow(follower.Id ?? 0, followedUserId ?? 0);
                if (follower.Id == 0 || followedUserId == 0)
                {
                    return RedirectToAction("All", "User");
                }
            }
            return RedirectToAction("All", "User");
>>>>>>> origin/master
        }
    }
}