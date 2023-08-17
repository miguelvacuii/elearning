using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller;
using elearning.src.StudentParticipation.Enrollment.Application.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.StudentParticipation.Enrollment.UI.Rest.Controller
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/enrollments")]
    [ApiController]
    [ControllerName("CreateCourse")]
    public class EnrollmenCreateController : CommandSyncControllerBase
    {

        public EnrollmenCreateController(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        ) : base(syncCommandBus, jsonApiEncoder) { }

        [HttpPost()]
        [Authorize(Roles = AuthUser.ROLE_STUDENT)]
        public IActionResult Create(CreateEnrollmentCommand command)
        {
            return Dispatch(command);
        }
    }
}
