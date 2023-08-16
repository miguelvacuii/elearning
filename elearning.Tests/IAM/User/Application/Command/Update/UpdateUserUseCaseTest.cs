using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.IAM.User.Domain.Service;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;
using elearning.src.Shared.Domain.Bus.Event;
using System.Collections.Generic;
using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Domain.Exception;

namespace elearning.Tests.IAM.User.Application.Command.Update
{
    [TestFixture]
    public class UpdateUserUseCaseTest
    {
        private UserId userId;
        private UserFirstName firstName;
        private UserLastName lastName;
        private UserAggregate user;

        [SetUp]
        public void Setup()
        {
            userId = UserIdStub.ByDefault();
            firstName = UserFirstNameStub.FromValue("Nombre");
            lastName = UserLastNameStub.FromValue("Apellido");
            user = UserStub.ByDefault();
        }

        [Test]
        public void ItShouldThrowExceptionIfUserNotFound()
        {
            string message = string.Format(
                "Not found any user with this id {0}",
                userId.Value
            );

            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository
                .Setup(m => m.Get(It.IsAny<UserId>()))
                .Throws(UserNotFoundException.FromId(userId));
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);

            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(
                userRepository.Object, eventProvider.Object, userFinder.Object
            );
            UserNotFoundException exception = Assert.Throws<UserNotFoundException>(
                () => updateUserUseCase.Invoke(
                    userId, firstName, lastName
                )
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void ItShouldGetUser()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);

            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(
                userRepository.Object, eventProvider.Object, userFinder.Object
            );
            updateUserUseCase.Invoke(
                userId, firstName, lastName
            );

            userRepository.Verify(
                m => m.Get(It.IsAny<UserId>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldUpdateUser()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock();
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);

            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(
                userRepository.Object, eventProvider.Object, userFinder.Object
            );
            updateUserUseCase.Invoke(
                userId, firstName, lastName
            );

            userRepository.Verify(
                m => m.Update(It.IsAny<UserAggregate>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldRecordReleasedUserEvents()
        {
            Mock<IUserRepository> userRepository = CreatedAtAndSetupUserRepositoryMock(); ;
            Mock<UniqueUser> uniqueUser = new Mock<UniqueUser>(userRepository.Object);
            Mock<IEventProvider> eventProvider = CreateAndSetupEventProviderMock();
            Mock<UserFinder> userFinder = new Mock<UserFinder>(userRepository.Object);

            UpdateUserUseCase updateUserUseCase = new UpdateUserUseCase(
                userRepository.Object, eventProvider.Object, userFinder.Object
            );
            updateUserUseCase.Invoke(
                userId, firstName, lastName
            );

            eventProvider.Verify(
                m => m.RecordEvents(It.IsAny<List<DomainEvent>>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<IUserRepository> CreatedAtAndSetupUserRepositoryMock()
        {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.Get(It.IsAny<UserId>())).Returns(user);
            userRepository.Setup(m => m.Update(It.IsAny<UserAggregate>())).Verifiable();
            return userRepository;
        }

        private Mock<IEventProvider> CreateAndSetupEventProviderMock()
        {
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            eventProvider.Setup(m => m.RecordEvents(It.IsAny<List<DomainEvent>>())).Verifiable();
            return eventProvider;
        }
    }
}
