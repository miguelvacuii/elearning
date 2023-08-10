using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.Tests.IAM.User.Domain.Stub;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using Moq;
using NUnit.Framework;
using System;

namespace elearning.Tests.IAM.User.Application.Query.FindUserById
{
    [TestFixture]
    public class FindUserByIdQueryHandlerTest
    {

        [Test]
        public void ItShouldInvokeUseCase()
        {
            FindUserByIdQuery query = new FindUserByIdQuery(UserIdStub.ByDefault().Value);
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<UserResponseConverter> userResponseConverter = SetUpUserResponseConverterMock();
            Mock<FindUserByIdUseCase> findUserByIdUseCase = SetUpFindUserByIdUseCaseMock(
                userRepository,
                userResponseConverter
            );
            FindUserByIdQueryHandler findUserByIdQueryHandler = new FindUserByIdQueryHandler(findUserByIdUseCase.Object);

            findUserByIdQueryHandler.Handle(query);

            findUserByIdUseCase.VerifyAll();
        }

        private Mock<UserResponseConverter> SetUpUserResponseConverterMock() {
            UserResponse user = CreateUserResponse();
            Mock<UserResponseConverter> userResponseConverter = new Mock<UserResponseConverter>();
            userResponseConverter.Setup(m => m.Convert(It.IsAny<UserAggregate>())).Returns(user);
            return userResponseConverter;
        }

        private UserResponse CreateUserResponse() {
            UserCreatedAt userCreatedAt = new UserCreatedAt(DateTime.Now);
            UserUpdatedAt userUpdatedAt = new UserUpdatedAt(DateTime.Now);
            return new UserResponse(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.ByDefault().Value,
                userCreatedAt.Value.ToString(),
                userUpdatedAt.Value.ToString()
            );
        }

        private Mock<FindUserByIdUseCase> SetUpFindUserByIdUseCaseMock(
            Mock<IUserRepository> userRepository,
            Mock<UserResponseConverter> userResponseConverter
        ) {
            Mock<FindUserByIdUseCase> findUserByIdUseCase = new Mock<FindUserByIdUseCase>(
                userRepository.Object,
                userResponseConverter.Object
            );
            findUserByIdUseCase.Setup(m => m.Invoke(It.IsAny<UserId>())).Verifiable();

            return findUserByIdUseCase;
        }
    }
}
