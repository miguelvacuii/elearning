using elearning.src.IAM.User.Application.Command.Update;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.IAM.User.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{id}")]
    [ApiController]
    [ControllerName("UpdateUser")]
    public class UserPatchController : CommandSyncControllerBase
    {
        public UserPatchController(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        ) : base(syncCommandBus, jsonApiEncoder) { }

        [HttpPatch()]
        [Authorize]
        public IActionResult SignUp(string id, UpdateUserCommand command)
        {
            command.id = id;
            return Dispatch(command);
        }
    }
}