using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoTwitter.Repositories;

namespace DemoTwitter.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        private readonly IUserProvider userProvider;

        [HttpGet]
        [Route("test")]
        public HttpResponseMessage Test()
        {
            //userProvider.GetUsers();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
