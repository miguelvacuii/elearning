using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.UI.Rest.Controller.Response;
using Microsoft.AspNetCore.Mvc;

namespace elearning.src.Shared.UI.Rest.Controller
{
    public class CommandSyncControllerBase : ControllerBase
    {
        private ICommandBus syncCommandBus;
        private IJsonApiEncoder jsonApiEncoder;

        public CommandSyncControllerBase(
            ICommandBus syncCommandBus,
            IJsonApiEncoder jsonApiEncoder
        )
        {
            this.syncCommandBus = syncCommandBus;
            this.jsonApiEncoder = jsonApiEncoder;
        }

        protected IActionResult Dispatch(ICommand command)
        {
            try
            {
                syncCommandBus.Dispatch(command);
                return StatusCode(200);
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
