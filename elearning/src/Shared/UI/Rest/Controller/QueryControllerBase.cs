using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller.Response;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.Shared.UI.Rest.Controller
{
    public class QueryControllerBase : ControllerBase
    {
        private IQueryBus query;
        private IJsonApiEncoder jsonApiEncoder;

        public QueryControllerBase(
            IQueryBus query,
            IJsonApiEncoder jsonApiEncoder
        )
        {
            this.query = query;
            this.jsonApiEncoder = jsonApiEncoder;
        }

        protected IActionResult Ask(IQuery Query)
        {
            try
            {
                IResponse response = query.Ask(Query);
                object Data = jsonApiEncoder.EncodeData(response);
                return StatusCode(200, response);
            }
            catch (System.Exception exception)
            {
                HttpResponse response = (new FailureResponseCreator(exception)).Create();
                object ErrorData = jsonApiEncoder.EncodeError(response);
                return StatusCode(response.Code, ErrorData);
            }
        }
    }
}
