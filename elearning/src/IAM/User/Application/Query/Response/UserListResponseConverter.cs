using System.Collections.Generic;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.Response
{
    public class UserListResponseConverter {

        private readonly UserResponseConverter userResponseConverter;

        public UserListResponseConverter(UserResponseConverter userResponseConverter) {
            this.userResponseConverter = userResponseConverter;
        }
        public virtual UserListResponse Convert(List<UserAggregate> users) {
            List<UserResponse> listUserResponse = new List<UserResponse>();

            foreach (UserAggregate user in users) {
                listUserResponse.Add(
                        userResponseConverter.Convert(user)
                ); ;
            }
            return new UserListResponse(listUserResponse);
        }
    }
}