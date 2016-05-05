 ﻿using System;
 ﻿using System.Collections;
 ﻿using System.Linq;
 ﻿using System.Net;
 ﻿using System.Web;
 ﻿using System.Web.Caching;
 ﻿using System.Web.Mvc;
 ﻿using System.Web.Security;
 ﻿using DemoTwitter.BusinessLayer.Users;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
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
            FormsAuthentication.SignOut();
            var urlToRemove = Url.Action("Index", "User");
            if (urlToRemove != null) HttpResponse.RemoveOutputCacheItem(urlToRemove);

            return RedirectToAction("Login", "Home");
        }
    }
}
