using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.IAM.User.Application.Command.SignUp
{
    public class SignUpUserCommand : ICommand {
        public string id { get; private set; }
        public string email { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string password { get; private set; }
        public string role { get; private set; }

        public SignUpUserCommand(
            string id,
            string email,
            string password,
            string firstName,
            string lastName,
            string role
        ) {
            this.id = id;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
        }
    }
}
