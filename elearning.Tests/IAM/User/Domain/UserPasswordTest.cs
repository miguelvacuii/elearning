using NUnit.Framework;
using elearning.src.Shared.Domain.Exception;
using elearning.Tests.IAM.User.Domain.Stub;
using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain
{
    public class UserPasswordTest
    {
        [Test]
        [TestCase("1234")]
        [TestCase("1234ab")]
        [TestCase("1234abcdefghijklmnñopqrstuvwxyz")]
        public void ItShouldReturnExceptionWhenPasswordNotMatchRegex(string password)
        {
            string message = "The password is invalid because of its value is " + password;

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserPasswordStub.FromValue(password)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void ItShouldReturnExceptionWhenPasswordNotEquals()
        {
            string password1 = "123456ab";
            string password2 = "12345678";
            string message = "Password are not equals";

            InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
                () => UserPassword.Validate(password1, password2)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }
    }
}
