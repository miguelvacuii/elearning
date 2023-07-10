using NUnit.Framework;
using Moq;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.Tests.IAM.User.Domain.Stub;
using elearning.src.IAM.User.Domain.Service.Exception;
using elearning.src.IAM.User.Domain.Service;

namespace elearning.Tests.IAM.User.Domain.Service
{
    public class UniqueUserTest {

        UserEmail email;

        [SetUp]
        public void Setup() {
            email = UserEmailStub.ByDefault();

        }

        [Test]
        public void ItShouldPassWhenEmailNotExists() {
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.FindByEmail(email)).Returns(
                (UserAggregate)null
            );

            UniqueUser uniqueUser = new UniqueUser(userRepository.Object);
            uniqueUser.CheckUserEmailNotExists(UserEmailStub.ByDefault());

            userRepository.VerifyAll();
        }

        [Test]
        public void ItShouldThrowExeptionWhenEmailExists() {
            string expectedMessage = string.Format(
                "User is already registered with this email {0}",
                email.Value
            );
            Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
            userRepository.Setup(m => m.FindByEmail(email)).Returns(
                UserStub.ByDefault()
            );

            UniqueUser uniqueUser = new UniqueUser(userRepository.Object);

            UserFoundException exception = Assert.Throws<UserFoundException>(
                () => uniqueUser.CheckUserEmailNotExists(UserEmailStub.ByDefault())
            );
            Assert.AreEqual(exception.Message, expectedMessage);
        }
    }
}
