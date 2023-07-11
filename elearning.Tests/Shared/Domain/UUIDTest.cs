using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;
using NUnit.Framework;

namespace elearning.Tests.Shared.Domain
{
    public class UUIDTest
    {
        [Test]
        public void ItShouldThrowExceptionWhenIsEmpty()
        {
            string message = "The UUID must not be empty";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => new UUID("")
            ); ;

            Assert.That(exception.Message, Is.EqualTo(message));

        }

        [Test]
        public void ItShouldThrowExceptionWhenFormatIsNotValid()
        {
            string userId = "1234";
            string message = "The UUID is invalid because of its value is " + userId;

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => new UUID(userId)
            ); ;

            Assert.That(exception.Message, Is.EqualTo(message));

        }
    }
}
