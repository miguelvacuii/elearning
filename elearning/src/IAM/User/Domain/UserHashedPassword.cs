using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain {
	public class UserHashedPassword : StringValueObject {
		public UserHashedPassword(string value) : base(value) {}
	}
}
