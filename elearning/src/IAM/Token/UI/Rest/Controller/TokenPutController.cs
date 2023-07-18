using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using elearning.src.IAM.Token.Application.Command.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using elearning.src.Shared.Domain;
using Microsoft.AspNetCore.Authorization;

namespace elearning.src.IAM.Token.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/tokens")]
    [ApiController]
    [ControllerName("CreateToken")]
    public class TokenPutController : CommandSyncControllerBase
    {
        public TokenPutController(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        ) : base(syncCommandBus, jsonApiEncoder) { }

        [HttpPut()]
        public IActionResult Create(CreateTokenCommand command)
        {
            IActionResult Result = Dispatch(command);
            var token = Request.Headers[HeaderNames.Authorization];
            Response.Headers[HeaderNames.Authorization] = token;
            return Result;
        }
    }
}
