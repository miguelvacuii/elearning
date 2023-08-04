using System.Collections.Generic;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.Response
{
    public class UserListResponseConverter {
        public virtual UserListResponse Convert(List<UserAggregate> users) {
            List<UserResponse> listUserResponse = new List<UserResponse>();

            foreach (UserAggregate user in users) {
                listUserResponse.Add(
                        new UserResponse(
                        user.id.Value,
                        user.email.Value,
                        user.firstName.Value,
                        user.lastName.Value,
                        user.role.Value,
                        user.createdAt.Value.ToString(),
                        user.updatedAt.Value.ToString()
                    )
                );
            }
            return new UserListResponse(listUserResponse);
        }
    }
}