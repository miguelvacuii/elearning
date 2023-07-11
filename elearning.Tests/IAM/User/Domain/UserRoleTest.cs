using NUnit.Framework;
using elearning.src.Shared.Domain.Exception;
using elearning.Tests.IAM.User.Domain.Stub;

namespace elearning.Tests.IAM.User.Domain
{
    public class UserRoleTest
    {

        [Test]
        public void ItShouldReturnExceptionWhenUserRoleIsInvalid()
        {
            string message = "This Role is not correct";
            string role = "";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserRoleStub.FromValue(role)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
