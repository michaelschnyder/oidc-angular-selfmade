using System.Web.Http;

namespace WebApiServerApp
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
