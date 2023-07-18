using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.User.Application.Query.FindUserByCredentials
{
    public class FindUserByCredentialsQuery : IQuery
    {
        public string email { get; private set; }
        public string password { get; private set; }

        public FindUserByCredentialsQuery(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
