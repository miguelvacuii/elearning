using NUnit.Framework;
using elearning.src.Shared.Domain.Exception;
using elearning.Tests.IAM.User.Domain.Stub;

namespace elearning.Tests.IAM.User.Domain
{
    public class UserLastNameTest
    {

        [Test]
        public void ItShouldReturnExceptionWhenLastNameIsLessThanThreeChars() {
            string message = "Length lastName cannot be less than 3";
            string lastName = "";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserLastNameStub.FromValue(lastName)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }


        [Test]
        public void ItShouldReturnExceptionWhenLastNameIsMoreThanThirteenChars() {
            string message = "Length lastName cannto be more than 30";
            string lastName = "dpewzvwocdaffbiptapedpewzvwocdaffbiptape";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserLastNameStub.FromValue(lastName)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}