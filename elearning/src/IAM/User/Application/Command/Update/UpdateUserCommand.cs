using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.IAM.User.Application.Command.Update
{
    public class UpdateUserCommand : ICommand
    {
        public string id { get; set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }

        public UpdateUserCommand(
            string id,
            string firstName,
            string lastName
        ) {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
