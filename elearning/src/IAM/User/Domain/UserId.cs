using elearning.src.Shared.Domain;

namespace elearning.src.IAM.User.Domain {
	public class UserId : UUID {
		public UserId(string value) : base(value) {}
	}
}
