using System.Linq;
using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;

namespace DemoTwitter.Controllers
{
    public class HomeController : Controller
    {
        private IUserBL userRepository = new UserBL();
        //
        // GET: /Home/

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
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid) return View(user);
            User userFromDatabase = userRepository
                .GetAllUsers()
                .FirstOrDefault(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
            if (userFromDatabase != null)
            {
                Session["LoggedUserID"] = userFromDatabase.Id.ToString();
                Session["LoggedUserFullName"] = userFromDatabase.FirstName + " " + userFromDatabase.LastName;
                return RedirectToAction("Add", "User");
            }
            return View(user);
        }

        public ActionResult AfterLogin()
        {
            if (Session["LoggedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
