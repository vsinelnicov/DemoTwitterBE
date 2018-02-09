using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoTwitter.DomainModel;
using DemoTwitter.Repositories;

namespace DemoTwitter.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        private readonly IUserProvider userProvider;

        [HttpGet]
        [Route("all")]
        public IEnumerable<User> Test()
        {
            IEnumerable<User> list = userProvider.GetUsers();
            return list;
            //return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}")]
        public User Test1(int id)
        {
            User user = userProvider.GetUserById(id);
            return user;
            //return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
