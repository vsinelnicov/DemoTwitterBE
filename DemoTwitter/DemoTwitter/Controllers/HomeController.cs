using System.Web.Mvc;
using DemoTwitter.BusinessLayer;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;
using System.Web.Security;

namespace DemoTwitter.WEB.Controllers
{
    [Authorize]
    [OutputCache(Duration = 1)]
    public class HomeController : Controller
    {
        private IUserBL userRepository;
        private HashHelper hashHelper = new HashHelper();

        public HomeController(IUserBL userBl)
        {
            userRepository = userBl;
        }

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
                User userFromDatabase = userRepository.GetByEmail(user.Email);
                if (userFromDatabase != null)
                {
                    var hashedInputPassword = hashHelper.CalculateMd5(user.Password);
                    if (userFromDatabase.Password == hashedInputPassword &&
                        userFromDatabase.Email == user.Email)
                    {
                        FormsAuthentication.SetAuthCookie(userFromDatabase.Email, false);
                        GetUserId(userFromDatabase);
                        this.Session["UserFullName"] = userFromDatabase.FirstName + " " + userFromDatabase.LastName;
                        return RedirectToAction("Index", "User");
                    }
                }
                ModelState.AddModelError("", "Wrong email and/or password");
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
                string email = userRepository.GetByEmail(user.Email).Email;
                if (email != null && email == user.Email)
                {
                    ModelState.AddModelError("", "A user with this email is already registered");
                }
                else
                {
                    user.Password = hashHelper.CalculateMd5(user.Password);
                    userRepository.Register(user);
                    return RedirectToAction("Login", "Home");
                }
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
