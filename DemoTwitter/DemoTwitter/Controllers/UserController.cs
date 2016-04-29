using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;
using DemoTwitter.Helpers;

namespace DemoTwitter.Controllers
{
    public class UserController : Controller
    {
        HashHelper hashHelper = new HashHelper();
        IUserBL userBl = new UserBL();

        //
        // GET: /User/

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            user.Password = hashHelper.CalculateMd5(user.Password);
            userBl.Register(user);
            return View();
        }

        public ActionResult ShowAllUsers()
        {
            return View(userBl.GetAllUsers());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
