using System;
using elearning.src.IAM.User.Application.Query.FindUserByCredentials;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Infrastructure.Service.Hashing;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Query.FindUserByCredentials
{
    [TestFixture]
    public class FindUserByCredentialsQueryHandlerTest
    {
        private FindUserByCredentialsQuery findUserByCredentialsQuery;

        [SetUp]
        public void Setup()
        {
            UserEmail email = UserEmailStub.ByDefault();
            UserPassword password = UserPasswordStub.ByDefault();

            findUserByCredentialsQuery = new FindUserByCredentialsQuery(
                email.Value, password.Value
            );
        }

        [Test]
        public void ItShouldHashPassword()
        {
            Mock<IHashing> hashing = CreateAndSetupHashingMock();
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<UserResponseForTokenConverter> userResponseConverter = new Mock<UserResponseForTokenConverter>();

            Mock<FindUserByCredentialsUseCase> findUserByCredentialsUseCase = CreateAndSetupFindUserByCredentialsUseCaseMock(
                userRepository, userResponseConverter
            );

            FindUserByCredentialsQueryHandler findUserByCredentialsQueryHandler = new FindUserByCredentialsQueryHandler(
                hashing.Object, findUserByCredentialsUseCase.Object
            );
            findUserByCredentialsQueryHandler.Handle(findUserByCredentialsQuery);

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
            Mock<UserResponseForTokenConverter> userResponseConverter = new Mock<UserResponseForTokenConverter>();

            Mock<FindUserByCredentialsUseCase> findUserByCredentialsUseCase = CreateAndSetupFindUserByCredentialsUseCaseMock(
                userRepository, userResponseConverter
            );

            FindUserByCredentialsQueryHandler findUserByCredentialsQueryHandler = new FindUserByCredentialsQueryHandler(
                hashing.Object, findUserByCredentialsUseCase.Object
            );
            findUserByCredentialsQueryHandler.Handle(findUserByCredentialsQuery);

            findUserByCredentialsUseCase.VerifyAll();
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

        private Mock<FindUserByCredentialsUseCase> CreateAndSetupFindUserByCredentialsUseCaseMock(
            Mock<IUserRepository> userRepository,
            Mock<UserResponseForTokenConverter> userResponseConverter
        )
        {
            Mock<FindUserByCredentialsUseCase> findUserByCredentialsUseCase = new Mock<FindUserByCredentialsUseCase>(
                userRepository.Object, userResponseConverter.Object
            );

            findUserByCredentialsUseCase.Setup(m => m.Invoke(
                It.IsAny<UserEmail>(),
                It.IsAny<UserHashedPassword>()
            )).Verifiable();

            return findUserByCredentialsUseCase;
        }
    }
}
