using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.Tests.IAM.Token.Domain.Stub
{
    public class UserResponseForTokenTests : IResponse
    {

        public string id { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string role { get; private set; }

        public UserResponseForTokenTests(string id, string email, string firstName, string lastName, string role)
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }
    }
}
