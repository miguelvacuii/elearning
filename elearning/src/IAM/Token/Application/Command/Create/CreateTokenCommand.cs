using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.IAM.Token.Application.Command.Create
{
    public class CreateTokenCommand : ICommand {

        public string email { get; private set; }
        public string password { get; private set; }

        public CreateTokenCommand(string email, string password) {
            this.email = email;
            this.password = password;
        }
    }
}
