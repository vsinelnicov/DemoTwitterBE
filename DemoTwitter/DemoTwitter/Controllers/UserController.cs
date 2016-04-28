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

        public ActionResult Remove()
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowAllUsers()
        {
           
            return View(userBl.GetAll());
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            userBl.Add(user);
            return View();
        }
        [HttpPost]
        public ActionResult Remove(User user)
        {
            userBl.Remove(user);
            return View();
        }
        [HttpPost]
        public ActionResult Update(User oldUser, User newUser)
        {
            userBl.Update(oldUser, newUser);
            return View();
        }
    }
}
