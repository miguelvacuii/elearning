using elearning.src.Shared.Domain.Exception;
using elearning.Tests.IAM.User.Domain.Stub;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Domain
{
    public class UserFirstNameTest {

        [Test]
        public void ItShouldReturnExceptionWhenLastNameIsLessThanThreeChars() {
            string message = "Length firstName cannot be less than 3";
            string lastName = "";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserFirstNameStub.FromValue(lastName)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }


        [Test]
        public void ItShouldReturnExceptionWhenLastNameIsMoreThanFiveteenChars() {
            string message = "Length firstName cannto be more than 15";
            string lastName = "dpewzvwocdaffbiptapedpewzvwocdaffbiptape";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserFirstNameStub.FromValue(lastName)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
