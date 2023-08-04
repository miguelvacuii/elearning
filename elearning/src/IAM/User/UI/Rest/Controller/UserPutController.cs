using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.IAM.User.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ControllerName("SignUpUser")]
    public class UserPutController : CommandSyncControllerBase
    {
        public UserPutController(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        ) : base(syncCommandBus, jsonApiEncoder) { }

        [HttpPut()]
        public IActionResult SignUp(SignUpUserCommand command)
        {
            return Dispatch(command);
        }
    }
}
