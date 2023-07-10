using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain.Stub
{
	public class UserHashedPasswordStub {

		public static UserHashedPassword ByDefault() {
			return new UserHashedPassword("aaAA11bbBB22");
		}

		public static UserHashedPassword FromValue(string value) {
			return new UserHashedPassword(value);
		}
	}
}
