using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.Shared.UI.Rest.Controller.Response
{
    public class HttpResponse : IResponse {
        public HttpResponse(int code, string message) {
            Code = code;
            Message = message;
        }

        public int Code { get; }
        public string Message { get; }
    }
}
