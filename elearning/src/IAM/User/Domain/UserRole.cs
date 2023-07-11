using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Domain
{
	public class UserRole : StringValueObject {
		public UserRole(string value) : base(value) {
			if (!AuthUser.Contains(value)) {
				throw InvalidAttributeException.FromText("This Role is not correct");
			}
		}
	}
}
