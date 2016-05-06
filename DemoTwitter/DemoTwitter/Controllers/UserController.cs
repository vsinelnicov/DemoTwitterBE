 ﻿using System;
 ﻿using System.Collections;
 ﻿using System.Configuration;
 ﻿using System.Linq;
 ﻿using System.Net;
 ﻿using System.Web;
 ﻿using System.Web.Mvc;
 ﻿using System.Web.Security;
 ﻿using DemoTwitter.BusinessLayer.Users;
 ﻿using DemoTwitter.Models;
 ﻿using PagedList;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserBL userBl = new UserBL();

        public ActionResult All(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
            return View(userBl.GetAllUsers().ToPagedList(pageNumber, pageSize));

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
    }
}
