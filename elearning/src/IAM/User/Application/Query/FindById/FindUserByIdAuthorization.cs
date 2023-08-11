using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Exception;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using elearning.src.Shared.Infrastructure.Security.Authorization;
using elearning.src.Shared.Infrastructure.Security.Authorization.Exception;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class FindUserByIdAuthorization : IQueryAuthorization
    {
        private OAuth oAuth;

        public FindUserByIdAuthorization(OAuth oAuth)
        {
            this.oAuth = oAuth;
        }

        public virtual void Authorize(dynamic request) {

            FindUserByIdQuery findUserByIdQuery = request as FindUserByIdQuery;
            AuthUser user = oAuth.User();
            UserRole role = new UserRole(user.role);
            UserId id = new UserId(findUserByIdQuery.id);

            if (user.IsAdministrator())
            {
                throw UnauthorizedException.FromRole(role);
            }

            if (!request.isInternalQuery && id.Value != user.id) {
                throw UserAuthorizationException.FromId(id);
            }
        }
    }
}
