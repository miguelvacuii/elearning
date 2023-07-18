using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.Response
{
    public class UserResponseForToken : IResponse
    {

        public string id { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string role { get; private set; }

        public UserResponseForToken(string id, string email, string firstName, string lastName, string role)
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }
    }
}
