using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.Response
{
    public class UserResponseConverter {
        public virtual UserResponse Convert(UserAggregate user) {
            return new UserResponse(
                user.id.Value,
                user.email.Value,
                user.firstName.Value,
                user.lastName.Value,
                user.role.Value,
                user.createdAt.Value.ToString(),
                user.updatedAt.Value.ToString()
            );
        }
    }
}
