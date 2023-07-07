using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Domain
{
	public class UserFirstName : StringValueObject
	{
		public const int MIN_LENGTH = 3;
		public const int MAX_LENGTH = 15;

		public UserFirstName(string value) : base(value)
		{
			if (value.Length < MIN_LENGTH)
			{
				throw InvalidAttributeException.FromMinLength("firstName", MIN_LENGTH);
			}

			if (value.Length > MAX_LENGTH)
			{
				throw InvalidAttributeException.FromMaxLength("firstName", MAX_LENGTH);
			}
		}
	}
}
