using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.LogisticModule.Data.Dtos;
using VirtoCommerce.LogisticModule.Data.Services;

namespace LogisticModule.Controllers.Api
{
    [RoutePrefix("")]
    public class LogisticModuleController : ApiController
    {
        private readonly ILogisticService _logisticService;

        public LogisticModuleController(ILogisticService logisticService)
        {
            _logisticService = logisticService;
        }
        
        [HttpGet]
        [Route("~/api/logistic/nearest")]
        [ResponseType(typeof(FulfillmentCenterDto))]
        public IHttpActionResult GetNearestFulfillmentCenter([FromBody]GettingNearestCenterRequestDto centerRequest)
        {
            FulfillmentCenterDto result = _logisticService.GetNearestFulfillmentCenter(centerRequest);
            return Ok(result);
        }
    }
}
