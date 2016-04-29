using System.Web.Mvc;
using DemoTwitter.BusinessLayer.Users;
using DemoTwitter.Models;

namespace DemoTwitter.Controllers
{
    public class UserController : Controller
    {
        IUserBL userBl = new UserBL();

        //
        // GET: /User/

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            userBl.Add(user);
            return View();
        }
        [HttpPost]
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
