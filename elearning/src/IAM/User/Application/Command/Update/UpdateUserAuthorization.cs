using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Exception;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using elearning.src.Shared.Infrastructure.Security.Authorization;

namespace elearning.src.IAM.User.Application.Command.Update
{
    public class UpdateUserAuthorization : ICommandAuthorization
    {
        private OAuth oAuth;

        public UpdateUserAuthorization(OAuth oAuth)
        {
            this.oAuth = oAuth;
        }

        public virtual void Authorize(dynamic request) {

            UpdateUserCommand updateUserCommand = request as UpdateUserCommand;
            AuthUser user = oAuth.User();
            UserId id = new UserId(updateUserCommand.id);

            if (id.Value != user.id) {
                throw UserAuthorizationException.FromId(id);
            }
        }
    }
}
