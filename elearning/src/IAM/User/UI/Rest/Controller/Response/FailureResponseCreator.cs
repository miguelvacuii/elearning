using System;
using System.ComponentModel.DataAnnotations;
using DomainExceptions = elearning.src.Shared.Domain.Exception;

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
            if (exception is DomainExceptions.ResourceNotFoundException)
            {
                code = 404;
            }
            return new HttpResponse(code, this.exception.Message);
        }
    }
}
