﻿using System;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;
using System.Web.Security;

namespace DemoTwitter.WEB.Controllers
{

    [OutputCache(Duration = 1)]
    public class HomeController : Controller
    {
        private IUserBL userRepository;
        private HashHelper hashHelper = new HashHelper();

        public HomeController(IUserBL userBl)
        {
            userRepository = userBl;
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                User userFromDatabase = userRepository.GetByEmail(user.Email);
                if (userFromDatabase != null)
                {
                    var hashedInputPassword = hashHelper.CalculateMd5(user.Password);
                    if (userFromDatabase.Password == hashedInputPassword &&
                        userFromDatabase.Email == user.Email)
                    {
                        FormsAuthentication.SetAuthCookie(userFromDatabase.Email, false);
                        SetSesionUserId(userFromDatabase);
                        this.Session["UserFullName"] = userFromDatabase.FirstName + " " + userFromDatabase.LastName;
                        return RedirectToAction("Index", "User");
                    }
                }
                ModelState.AddModelError("", "Wrong email and/or password");
            }

            return View();
        }

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
                if (userRepository.Register(user))
                {
                    return RedirectToAction("Login", "Home");
                }
                return RedirectToAction("Error", "Home");

            }
            return View(user);
        }

        private void SetSesionUserId(User user)
        {
            Session["UserID"] = user.Id;
        }
    }
}
