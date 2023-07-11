using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Domain
{
	public class UserLastName : StringValueObject
	{
		public const int MIN_LENGTH = 3;
		public const int MAX_LENGTH = 30;

		public UserLastName(string value) : base(value) {
			if (value.Length < MIN_LENGTH) {
				throw InvalidAttributeException.FromMinLength("lastName", MIN_LENGTH);
			}

			if (value.Length > MAX_LENGTH) {
				throw InvalidAttributeException.FromMaxLength("lastName", MAX_LENGTH);
			}
		}
	}
}
