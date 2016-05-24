using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;
using System.Web.Security;
using log4net;

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
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                string email = userRepository.GetByEmail(user.Email).Email;
                if (email != null && email == user.Email)
                {
                    log.Info("User didn't register");
                    ModelState.AddModelError("", "A user with this email is already registered");
                }
                else
                {
                    user.Password = hashHelper.CalculateMd5(user.Password);
                    userRepository.Register(user);
                    log.Info("A new user registered");
                    return RedirectToAction("Login", "Home");
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
