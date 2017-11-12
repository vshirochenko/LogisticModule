using System.Data.Entity;
using System.Linq;
using System.Web.Http;
namespace LogisticModule.Controllers.Api
{
    [RoutePrefix("api/LogisticModule")]
    public class ManagedModuleController : ApiController
    {
        // GET: api/managedModule
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}
