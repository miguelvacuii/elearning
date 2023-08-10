using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.IAM.User.Application.Command.Update
{
    public class UpdateUserCommandHandler : ICommandHandler
    {
        private readonly UpdateUserUseCase updateUserUseCase;

        public UpdateUserCommandHandler(
            UpdateUserUseCase updateUserUseCase
        ) {
            this.updateUserUseCase = updateUserUseCase;
        }

        public void Handle(ICommand command)
        {
            UpdateUserCommand updateUserCommand = command as UpdateUserCommand;

            UserId id = new UserId(updateUserCommand.id);
            UserFirstName firstName = new UserFirstName(updateUserCommand.firstName);
            UserLastName lastName = new UserLastName(updateUserCommand.lastName);

            updateUserUseCase.Invoke(id, firstName, lastName);
        }
    }
}
