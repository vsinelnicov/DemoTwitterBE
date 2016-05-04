using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;
using DemoTwitter.WEB.Helpers;

namespace DemoTwitter.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IUserBL userRepository = new UserBL();
        private HashHelper hashHelper = new HashHelper();

        public ActionResult Index()
        {
            return View();
        }

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
                if (userFromDatabase.Password == hashedInputPassword)
                {
                    GetUserId(userFromDatabase);
                    Session["UserFullName"] = userFromDatabase.FirstName + " " + userFromDatabase.LastName;
                    return RedirectToAction("Index", "User");
                }
            }
            return View();
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
