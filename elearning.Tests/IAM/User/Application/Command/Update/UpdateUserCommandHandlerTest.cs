using elearning.src.IAM.User.Application.Command.Update;
using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Command.Update
{
    [TestFixture]
    public class UpdateUserCommandHandlerTest
    {
        private UpdateUserCommand updateUserCommand;

        [SetUp]
        public void Setup()
        {
            UserId userId = UserIdStub.ByDefault();
            UserFirstName firstName = UserFirstNameStub.ByDefault();
            UserLastName lastName = UserLastNameStub.ByDefault();

            updateUserCommand = new UpdateUserCommand(
                userId.Value, firstName.Value, lastName.Value
            );
        }

        [Test]
        public void ItShouldInvokeUseCase()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<UpdateUserUseCase> updateUserUseCase = CreateAndSetupUpdateUserUseCaseMock(
                userRepository, eventProvider
            );

            UpdateUserCommandHandler updateUserCommandHandler = new UpdateUserCommandHandler(
                updateUserUseCase.Object
            );
            updateUserCommandHandler.Handle(updateUserCommand);

            updateUserUseCase.VerifyAll();
        }

        private Mock<UpdateUserUseCase> CreateAndSetupUpdateUserUseCaseMock(
            Mock<IUserRepository> userRepository,
            Mock<IEventProvider> eventProvider
        )
        {
            Mock<UpdateUserUseCase> updateUserUseCase = new Mock<UpdateUserUseCase>(
                userRepository.Object, eventProvider.Object
            );
            updateUserUseCase.Setup(m => m.Invoke(
                It.IsAny<UserId>(),
                It.IsAny<UserFirstName>(),
                It.IsAny<UserLastName>()
            )).Verifiable();
            return updateUserUseCase;
        }
    }
}
