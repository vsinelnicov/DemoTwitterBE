using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;
using System.IO;
using System.Threading.Tasks;

namespace DemoTwitter.WEB.Controllers
{

    public class HomeController : Controller
    {
        private IUserBL userRepository = new UserBL();
        private HashHelper hashHelper = new HashHelper();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {

                User userFromDatabase = userRepository.GetByUsername(user.Username);
                var hashedInputPassword = hashHelper.CalculateMd5(user.Password);
                if (userFromDatabase.Password == hashedInputPassword && userFromDatabase.Username == user.Username)
                {
                    GetUserId(userFromDatabase);
                    Session["UserFullName"] = userFromDatabase.FirstName + " " + userFromDatabase.LastName;
                    return RedirectToAction("Index", "User");
                }

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
                userRepository.Register(user);
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(user);
            }

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
