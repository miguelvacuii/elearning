
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Application.Query.Exception;
using elearning.Tests.IAM.User.Domain.Stub;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Query.FindUserById
{
    [TestFixture]
    public class FindUserByIdUseCaseTest
    {
        UserId userId;
        UserAggregate user;
        UserResponse userResponse;
        FindUserByIdUseCase findUserByIdUseCase;

        [SetUp]
        public void Setup() {
            userId = UserIdStub.ByDefault();
            user = UserStub.ByDefault();
            userResponse = new UserResponse(
                user.id.Value,
                user.email.Value,
                user.firstName.Value,
                user.lastName.Value,
                user.role.Value,
                user.createdAt.Value.ToString(),
                user.updatedAt.Value.ToString()
            ); ;
        }

        [Test]
        public void ItShouldThrowExceptionIfUserNotFound() {
            string message = string.Format(
                "Not found any user with this id {0}",
                userId.Value
            );
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository
                .Setup(m => m.Get(It.IsAny<UserId>()))
                .Throws(UserNotFoundException.FromId(userId));
            Mock<UserResponseConverter> userResponseConverter = SetUpUserResponseConverterMock(userResponse);
            findUserByIdUseCase = new FindUserByIdUseCase(
                userRepository.Object,
                userResponseConverter.Object
            );

            UserNotFoundException exception = Assert.Throws<UserNotFoundException>(
                () => findUserByIdUseCase.Invoke(userId)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void ItShouldGetUser() {
            Mock<IUserRepository> userRepository = SetUpIUserRepositoryMock(user);
            Mock<UserResponseConverter> userResponseConverter = SetUpUserResponseConverterMock(userResponse);
            findUserByIdUseCase = new FindUserByIdUseCase(
                userRepository.Object,
                userResponseConverter.Object
            );

            findUserByIdUseCase.Invoke(userId);

            userRepository.Verify(
                m => m.Get(It.IsAny<UserId>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldCallUserResponseConverter() {
            Mock<IUserRepository> userRepository = SetUpIUserRepositoryMock(user);
            Mock<UserResponseConverter> userResponseConverter = SetUpUserResponseConverterMock(userResponse);
            findUserByIdUseCase = new FindUserByIdUseCase(
                userRepository.Object,
                userResponseConverter.Object
            );

            findUserByIdUseCase.Invoke(userId);

            userResponseConverter.Verify(
                m => m.Convert(It.IsAny<UserAggregate>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<IUserRepository> SetUpIUserRepositoryMock(UserAggregate user) {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository
                .Setup(m => m.Get(It.IsAny<UserId>()))
                .Returns(user);
            return userRepository;
        }

        private Mock<UserResponseConverter> SetUpUserResponseConverterMock(UserResponse userResponse) {
            Mock<UserResponseConverter> userResponseConverter = new Mock<UserResponseConverter>();
            userResponseConverter
                .Setup(m => m.Convert(It.IsAny<UserAggregate>()))
                .Returns(userResponse);
            return userResponseConverter;
        }
    }
}
