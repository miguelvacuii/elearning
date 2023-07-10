using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain.Stub
{
	public class UserFirstNameStub {

		public static UserFirstName ByDefault() {
			return new UserFirstName("Craft");
		}

		public static UserFirstName FromValue(string value) {
			return new UserFirstName(value);
		}
	}
}
