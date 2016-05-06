using System;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;
using System.Web.Security;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    [OutputCache(Duration = 1)]
    public class HomeController : Controller
    {
        private IUserBL userRepository = new UserBL();
        private HashHelper hashHelper = new HashHelper();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User userFromDatabase = userRepository.GetByUsername(user.Username);
                    if (userFromDatabase != null)
                    {
                        FormsAuthentication.SetAuthCookie(userFromDatabase.Username, false);
                        var hashedInputPassword = hashHelper.CalculateMd5(user.Password);
                        if (userFromDatabase.Password == hashedInputPassword &&
                            userFromDatabase.Username == user.Username)
                        {
                            GetUserId(userFromDatabase);
                            this.Session["UserFullName"] = userFromDatabase.FirstName + " " + userFromDatabase.LastName;
                            return RedirectToAction("Index", "User");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = hashHelper.CalculateMd5(user.Password);
                userRepository.Register(user);
                return RedirectToAction("Login", "Home");
            }
            return View(user);
        }

        public int GetUserId(User user)
        {
            int userId;
            Session["UserID"] = user.Id;
            int.TryParse(Session["UserID"].ToString(), out userId);
            return userId;
        }
    }
}
