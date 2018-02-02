using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DemoTwitter.Repositories;
using DemoTwitter.WebApi.Models;

namespace DemoTwitter.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        public AccountController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        private readonly IUserProvider userProvider;

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public HttpResponseMessage Authenticate(AuthenticationModel model)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("json")]
        public string Test()
        {
            return "Hello";
        }
    }
}
