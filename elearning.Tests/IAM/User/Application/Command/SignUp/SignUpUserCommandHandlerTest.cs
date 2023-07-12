using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Service;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Service.Hashing;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Command
{
    [TestFixture]
    public class SignUpUserCommandHandlerTest
    {
        private SignUpUserCommand signUpUserCommand;

        [SetUp]
        public void Setup()
        {
            UserId userId = UserIdStub.ByDefault();
            UserEmail email = UserEmailStub.ByDefault();
            UserFirstName firstName = UserFirstNameStub.ByDefault();
            UserLastName lastName = UserLastNameStub.ByDefault();
            UserRole role = UserRoleStub.ByDefault();
            UserPassword password = UserPasswordStub.ByDefault();

            signUpUserCommand = new SignUpUserCommand(
                userId.Value, email.Value, firstName.Value, lastName.Value, password.Value, role.Value
            );
        }

        [Test]
        public void ItShouldHashPassword()
        {
            Mock<IHashing> hashing = CreateAndSetupHashingMock();
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);

            Mock<SignUpUserUseCase> signUpUserUseCase = CreateAndSetupSignUpUserUseCaseMock(
                userRepository, uniqueUser, eventProvider
            );

            SignUpUserCommandHandler signUpUserCommandHandler = new SignUpUserCommandHandler(
                hashing.Object, signUpUserUseCase.Object
            );
            signUpUserCommandHandler.Handle(signUpUserCommand);

            hashing.Verify(
                m => m.Hash(It.IsAny<string>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldInvokeUseCase()
        {
            Mock<IHashing> hashing = CreateAndSetupHashingMock();
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);
            Mock<SignUpUserUseCase> signUpUserUseCase = CreateAndSetupSignUpUserUseCaseMock(
                userRepository, uniqueUser, eventProvider
            );

            SignUpUserCommandHandler signUpUserCommandHandler = new SignUpUserCommandHandler(
                hashing.Object, signUpUserUseCase.Object
            );
            signUpUserCommandHandler.Handle(signUpUserCommand);

            signUpUserUseCase.VerifyAll();
        }

        private Mock<IHashing> CreateAndSetupHashingMock()
        {
            HashedPassword hashedPassword = new HashedPassword(
                UserHashedPasswordStub.ByDefault().Value
            );
            Mock<IHashing> hashing = new Mock<IHashing>();
            hashing.Setup(m => m.Hash(It.IsAny<string>())).Returns(hashedPassword);
            return hashing;
        }

        private Mock<SignUpUserUseCase> CreateAndSetupSignUpUserUseCaseMock(
            Mock<IUserRepository> userRepository,
            Mock<UniqueUser> uniqueUser,
            Mock<IEventProvider> eventProvider
        )
        {
            Mock<SignUpUserUseCase> signUpUserUseCase = new Mock<SignUpUserUseCase>(
                userRepository.Object, uniqueUser.Object, eventProvider.Object
            );
            signUpUserUseCase.Setup(m => m.Invoke(
                It.IsAny<UserId>(),
                It.IsAny<UserEmail>(),
                It.IsAny<UserFirstName>(),
                It.IsAny<UserLastName>(),
                It.IsAny<UserHashedPassword>(),
                It.IsAny<UserRole>()
            )).Verifiable();
            return signUpUserUseCase;
        }
    }
}
