using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiServerApp.Controller
{
    public class AmazingSecret
    {
        public long Id { get; set; }

        public string Topic { get; set; }

        public string Insight { get; set; }
    }

    [Authorize]
    public class AmazingSecretsController : ApiController
    {
        private List<AmazingSecret> allSecrets = new List<AmazingSecret>(new []
        {
            new AmazingSecret { Id = 1, Topic = "Nature", Insight = "The average person will accidentally eat 11 spiders in their sleep." },
            new AmazingSecret { Id = 4, Topic = "Nature", Insight = "A bee can smell with its knees." },
            new AmazingSecret { Id = 3, Topic = "Geo", Insight = "Denmark has the oldest of all national flags" },
            new AmazingSecret { Id = 11, Topic = "Switzerland", Insight = "In Switzerland, it is illegal to keep just one guinea pig. You got to have them in pairs" },
            new AmazingSecret { Id = 2, Topic = "Switzerland", Insight = "James Bonds mother is Swiss." },
            new AmazingSecret { Id = 5, Topic = "Germany", Insight = "The first printed book was in German" },
            new AmazingSecret { Id = 7, Topic = "Germany", Insight = "There are over 1,000 kinds of sausages in Germany." },
            new AmazingSecret { Id = 6, Topic = "UK", Insight = "If you reach your 100th birthday, you get a personalized card from the Queen" },
            new AmazingSecret { Id = 9, Topic = "England", Insight = "It is against the law to get drunk in a pub in England." },
            new AmazingSecret { Id = 8, Topic = "Serbia", Insight = "Belgrade translates to \"white city\"." },
            new AmazingSecret { Id = 10, Topic = "Belgrade", Insight = "If a person's nickname is \"Jonny\", his name's called \"Nikola\"" },
        });

        [HttpGet]
        [Route("secrets")]
        public IHttpActionResult GetAll()
        {
            return this.Ok(this.allSecrets.OrderBy(s => s.Id).ToList());
        }

        [HttpGet]
        [Route("secrets/{id}")]
        public IHttpActionResult GetSingle(long id)
        {
            var element = this.allSecrets.FirstOrDefault(s => s.Id == id);

            if (element == null) return this.NotFound();

            return this.Ok(element);
        }
    }
}
