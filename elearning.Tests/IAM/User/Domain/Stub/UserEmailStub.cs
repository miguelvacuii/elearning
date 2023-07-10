using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain.Stub
{
	public class UserEmailStub {

		public static UserEmail ByDefault() {
			return new UserEmail("example@example.com");
		}

		public static UserEmail FromValue(string value) {
			return new UserEmail(value);
		}
	}
}
