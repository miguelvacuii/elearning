using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.IAM.User.Domain.Service;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Command
{
    [TestFixture]
    public class SignUpUserUseCaseTest
    {
        private UserId userId;
        UserEmail email;
        UserFirstName firstName;
        UserLastName lastName;
        UserRole role;
        UserHashedPassword userHashedPassword;

        [SetUp]
        public void Setup()
        {
            userId = UserIdStub.ByDefault();
            email = UserEmailStub.ByDefault();
            firstName = UserFirstNameStub.ByDefault();
            lastName = UserLastNameStub.ByDefault();
            role = UserRoleStub.ByDefault();
            userHashedPassword = UserHashedPasswordStub.ByDefault();
        }

        [Test]
        public void ItShouldCheckUserEmailNotExists()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<UniqueUser> uniqueUser = CreateAndSetupUniqueUserMock(userRepository);

            SignUpUserUseCase signUpUserUseCase = new SignUpUserUseCase(
                userRepository.Object, uniqueUser.Object
            );
            signUpUserUseCase.Invoke(
                userId, email, firstName, lastName, userHashedPassword, role
            );

            uniqueUser.Verify(
                m => m.CheckUserEmailNotExists(It.IsAny<UserEmail>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldAddUser()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);

            SignUpUserUseCase signUpUserUseCase = new SignUpUserUseCase(
                userRepository.Object, uniqueUser.Object
            );
            signUpUserUseCase.Invoke(
                userId, email, firstName, lastName, userHashedPassword, role
            );

            userRepository.Verify(
                m => m.Add(It.IsAny<UserAggregate>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<IUserRepository> CreatedAtAndSetupUserRepositoryMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.Add(It.IsAny<UserAggregate>())).Verifiable();
            return userRepository;
        }

        private Mock<UniqueUser> CreateAndSetupUniqueUserMock(Mock<IUserRepository> userRepository)
        {
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);
            uniqueUser.Setup(m => m.CheckUserEmailNotExists(It.IsAny<UserEmail>())).Verifiable();
            return uniqueUser;
        }
    }
}
