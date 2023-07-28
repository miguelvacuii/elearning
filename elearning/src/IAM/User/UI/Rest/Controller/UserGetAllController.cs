using elearning.src.IAM.User.Application.Query.FindByCriteria;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.IAM.User.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ControllerName("FindUsersByCriteria")]
    public class UserGetAllController : QueryControllerBase
    {
        public UserGetAllController(
         IQueryBus queryBus,
         IJsonApiEncoder jsonApiEncoder
        ) : base(queryBus, jsonApiEncoder) {}

        [HttpGet()]
        [Authorize(Roles = AuthUser.ROLE_ADMINISTRATOR)]
        public IActionResult GetUsers()
        {
            return Ask(new FindUsersByCriteriaQuery(HttpContext.Request.Query));
        }
    }
}

