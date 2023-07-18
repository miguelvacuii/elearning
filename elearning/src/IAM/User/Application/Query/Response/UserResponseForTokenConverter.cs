using elearning.src.Shared.Domain.Bus.Query;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.Response
{

    public class UserResponseForTokenConverter
    {

        public IResponse Convert(UserAggregate user)
        {
            return new UserResponseForToken(
                user.id.Value,
                user.email.Value,
                user.firstName.Value,
                user.lastName.Value,
                user.role.Value
            );
        }
    }
}
