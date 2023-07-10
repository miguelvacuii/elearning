using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain.Stub
{
	public class UserRoleStub {

		public static UserRole ByDefault() {
			return new UserRole("student");
		}

		public static UserRole FromValue(string value) {
			return new UserRole(value);
		}
	}
}
