using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.IAM.User.Domain.Service;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;
using elearning.src.Shared.Domain.Bus.Event;
using System.Collections.Generic;

namespace elearning.Tests.IAM.User.Application.Command.SignUp
{
    [TestFixture]
    public class SignUpUserUseCaseTest
    {
        private UserId userId;
        private UserEmail email;
        private UserFirstName firstName;
        private UserLastName lastName;
        private UserRole role;
        private UserHashedPassword userHashedPassword;

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
        public void ItShouldCheckUserNotExists()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<IUserSpecificationFactory> userSpecificationFactory = new Mock<IUserSpecificationFactory>();
            Mock<UniqueUser> uniqueUser = CreateAndSetupUniqueUserMock(userRepository, userSpecificationFactory);
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();

            SignUpUserUseCase signUpUserUseCase = new SignUpUserUseCase(
                userRepository.Object, uniqueUser.Object, eventProvider.Object
            );
            signUpUserUseCase.Invoke(
                userId, email, firstName, lastName, userHashedPassword, role
            );

            uniqueUser.Verify(
                m => m.CheckUserNotExists(It.IsAny<UserAggregate>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldAddUser()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<IUserSpecificationFactory> userSpecificationFactory = new Mock<IUserSpecificationFactory>();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object, userSpecificationFactory.Object);
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();

            SignUpUserUseCase signUpUserUseCase = new SignUpUserUseCase(
                userRepository.Object, uniqueUser.Object, eventProvider.Object
            );
            signUpUserUseCase.Invoke(
                userId, email, firstName, lastName, userHashedPassword, role
            );

            userRepository.Verify(
                m => m.Add(It.IsAny<UserAggregate>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldRecordReleasedUserEvents()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            Mock<IUserSpecificationFactory> userSpecificationFactory = new Mock<IUserSpecificationFactory>();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object, userSpecificationFactory.Object);
            Mock<IEventProvider> eventProvider = CreateAndSetupEventProviderMock();

            SignUpUserUseCase signUpUserUseCase = new SignUpUserUseCase(
                userRepository.Object, uniqueUser.Object, eventProvider.Object
            );
            signUpUserUseCase.Invoke(
                userId, email, firstName, lastName, userHashedPassword, role
            );

            eventProvider.Verify(
                m => m.RecordEvents(It.IsAny<List<DomainEvent>>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<IUserRepository> CreatedAtAndSetupUserRepositoryMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.Add(It.IsAny<UserAggregate>())).Verifiable();
            return userRepository;
        }

        private Mock<UniqueUser> CreateAndSetupUniqueUserMock(
            Mock<IUserRepository> userRepository,
            Mock<IUserSpecificationFactory> userSpecificationFactory
        ) {
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object, userSpecificationFactory.Object);
            uniqueUser.Setup(m => m.CheckUserNotExists(It.IsAny<UserAggregate>())).Verifiable();
            return uniqueUser;
        }

        private Mock<IEventProvider> CreateAndSetupEventProviderMock()
        {
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            eventProvider.Setup(m => m.RecordEvents(It.IsAny<List<DomainEvent>>())).Verifiable();
            return eventProvider;
        }
    }
}
