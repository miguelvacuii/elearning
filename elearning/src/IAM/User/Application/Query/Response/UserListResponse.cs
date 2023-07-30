using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.Response
{
    public class UserListResponse : IResponse
    {
        public List<UserResponse> data { get; private set; }

        public UserListResponse(List<UserResponse> data)
        {
            this.data = data;
        }
    }
}
