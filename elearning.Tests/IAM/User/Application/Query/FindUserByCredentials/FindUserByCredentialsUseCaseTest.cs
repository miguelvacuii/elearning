using Moq;
using NUnit.Framework;
using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Application.Query.FindUserByCredentials;
using elearning.Tests.IAM.User.Domain.Stub;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.Tests.IAM.User.Application.Query.FindUserByCredentials
{
    [TestFixture]
    public class FindUserByCredentialsUseCaseTest
    {
        UserEmail email;
        UserHashedPassword userHashedPassword;
        UserAggregate user;

        [SetUp]
        public void Setup()
        {
            email = UserEmailStub.ByDefault();
            userHashedPassword = UserHashedPasswordStub.ByDefault();
            user = UserStub.ByDefault();

        }

        [Test]
        public void ItShouldFindUser()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UserResponseForTokenConverter> userConverter = CreateAndSetupUserResponseForTokenConverter();

            FindUserByCredentialsUseCase findUserByCredentialsUseCase = new FindUserByCredentialsUseCase (
                userRepository.Object, userConverter.Object
            );

            findUserByCredentialsUseCase.Invoke(
               email, userHashedPassword
            );

            userRepository.Verify(
                m => m.FindByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldFindUserAndConvert()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UserResponseForTokenConverter> userConverter = CreateAndSetupUserResponseForTokenConverter();

            FindUserByCredentialsUseCase findUserByCredentialsUseCase = new FindUserByCredentialsUseCase(
                userRepository.Object, userConverter.Object
            );

            findUserByCredentialsUseCase.Invoke(
               email, userHashedPassword
            );

            userConverter.Verify(
                m => m.Convert(It.IsAny<UserAggregate>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<IUserRepository> CreatedAtAndSetupUserRepositoryMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.FindByEmailAndPassword(It.IsAny<UserEmail>(), It.IsAny<UserHashedPassword>())).Verifiable();
            return userRepository;
        }

        private Mock<UserResponseForTokenConverter> CreateAndSetupUserResponseForTokenConverter()
        {
            Mock<UserResponseForTokenConverter> userConverter = new Mock<UserResponseForTokenConverter>();
            userConverter.Setup(m => m.Convert(It.IsAny<UserAggregate>())).Verifiable();
            return userConverter;
        }
    }
}
