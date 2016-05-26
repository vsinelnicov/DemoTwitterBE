using System.IO;
using System.Web;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;
using System.Web.Security;
using log4net;
using Microsoft.Ajax.Utilities;

namespace DemoTwitter.WEB.Controllers
{

    [OutputCache(Duration = 1)]
    public class HomeController : Controller
    {
        private IUserBL userRepository;
        private HashHelper hashHelper = new HashHelper();
        private static ILog log = LogManager.GetLogger(typeof(HomeController));

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
        //[ValidateAntiForgeryToken]
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
                        log.Info("User logged in Succesfully");
                        return RedirectToAction("Index", "User");
                    }
                }
                log.Info("User didn't logged in");
                ModelState.AddModelError("", "Wrong email and/or password");

            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(User user, HttpPostedFileBase avatar)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = userRepository.GetByEmail(user.Email);
                if (avatar != null && avatar.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(avatar.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    if ((fileExtension == ".jpeg") || (fileExtension == ".png") || (fileExtension == ".jpg"))
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/img/Avatars"), fileName);
                        avatar.SaveAs(path);
                        user.Avatar = fileName;
                        if (userFromDb == null || userFromDb.Email != user.Email)
                        {
                            user.Password = hashHelper.CalculateMd5(user.Password);
                            userRepository.Register(user);
                            log.Info("A new user registered");
                            return RedirectToAction("Login", "Home");
                        }
                    }
                    log.Info("User didn't register");
                    ModelState.AddModelError("", "A user with this email is already registered");
                }
            }
            return View(user);
        }

        private void SetSesionUserId(User user)
        {
            Session["UserID"] = user.Id;
        }
    }
}
