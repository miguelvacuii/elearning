using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain.Stub
{
	public class UserLastNameStub {

		public static UserLastName ByDefault() {
			return new UserLastName("Craft");
		}

		public static UserLastName FromValue(string value) {
			return new UserLastName(value);
		}
	}
}
