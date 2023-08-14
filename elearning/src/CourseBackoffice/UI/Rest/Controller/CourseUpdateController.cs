using elearning.src.CourseBackoffice.Application.Command.Create;
using elearning.src.CourseBackoffice.Application.Command.Publish;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.CourseBackoffice.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/courses/{id}")]
    [ApiController]
    [ControllerName("UpdateCourse")]
    public class CourseUpdateController : CommandSyncControllerBase {

        public CourseUpdateController(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        ) : base(syncCommandBus, jsonApiEncoder) { }

        [HttpPatch()]
        [Authorize(Roles = AuthUser.ROLE_ADMINISTRATOR)]
        public IActionResult Publish(string id)
        {
            PublishCourseCommand command = new PublishCourseCommand(id);
            return Dispatch(command);
        }
    }
}
