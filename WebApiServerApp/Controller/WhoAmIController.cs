using System.Web.Http;

namespace WebApiServerApp.Controller
{
    public class WhoAmIController : ApiController
    {
        [HttpGet]
        [Route("whoami")]
        public IHttpActionResult WhoAmI()
        {
            return this.Ok(this.RequestContext.Principal);
        }
    }
}
