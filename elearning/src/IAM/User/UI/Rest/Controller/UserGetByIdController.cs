using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace elearning.src.IAM.User.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{id}")]
    [ApiController]
    [ControllerName("GetUser")]
    public class UserGetByIdController : QueryControllerBase
    {
        private readonly ILogger logger;

        public UserGetByIdController(
            IQueryBus queryBus,
            IJsonApiEncoder jsonApiEncoder,
            ILogger<UserGetByIdController> logger
        ) : base(queryBus, jsonApiEncoder) {
            this.logger = logger;
        }

        [HttpGet()]
        [Authorize(Roles = AuthUser.ROLE_STUDENT)]
        public IActionResult GetById(string id)
        {
            logger.LogInformation("Getting user by id: {}", id);
            return Ask(new FindUserByIdQuery(id));
        }
    }
}
