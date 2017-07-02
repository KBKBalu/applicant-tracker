using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ApplicantTracker.Controllers
{
    [Authorize]
    public abstract class BaseController : ApiController
    {//The 'ObjectContent`1' type failed to serialize the response body for content type 'application/xml; charset=utf-8'. web api
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}

