using elearning.src.Shared.Domain.Exception;
using elearning.Tests.IAM.User.Domain.Stub;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Domain
{
	public class UserEmailTest {
		[Test]
		public void ItShouldReturnExceptionWhenEmailIsNotValid() {
			string userEmail = "xxxx";
			string message = string.Format(
				"The email is invalid because of its value is {0}",
				userEmail
			);

			InvalidAttributeException exception = Assert.Throws<InvalidAttributeException>(
				() => UserEmailStub.FromValue(userEmail)
			);

			Assert.That(exception.Message, Is.EqualTo(message));
		}
	}
}

