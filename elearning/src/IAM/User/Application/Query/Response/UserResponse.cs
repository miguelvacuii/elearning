using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.Response
{
    public class UserResponse
    {

        public string id { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string role { get; private set; }
        public string createdAt { get; private set; }
        public string updatedAt { get; private set; }

        public UserResponse(string id, string email, string firstName, string lastName, string role, string createdAt, string updatedAt)
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }
    }
}