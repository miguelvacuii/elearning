using System;
using System.ComponentModel.DataAnnotations;

namespace elearning.src.Shared.UI.Rest.Controller.Response
{
    public class FailureResponseCreator : IHttpResponseCreator
    {
        private Exception exception;

        public FailureResponseCreator(Exception exception) {
            this.exception = exception;
        }

        public HttpResponse Create() {
            int code = 500;
            if (exception is ValidationException) {
                code = 400;
            }
            return new HttpResponse(code, this.exception.Message);
        }
    }
}
