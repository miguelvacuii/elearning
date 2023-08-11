using elearning.src.CourseBackoffice.Application.Command.Create;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.CourseBackoffice.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/courses")]
    [ApiController]
    [ControllerName("CreateCourse")]
    public class CourseCreateController : CommandSyncControllerBase {

        public CourseCreateController(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        ) : base(syncCommandBus, jsonApiEncoder) { }

        [HttpPost()]
        [Authorize(Roles = AuthUser.ROLE_TEACHER)]
        public IActionResult SignUp(CreateCourseCommand command)
        {
            return Dispatch(command);
        }
    }
}
