using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.CourseBackoffice.Domain
{
    public class CourseName : StringValueObject
	{
		public const int MIN_LENGTH = 3;
		public const int MAX_LENGTH = 30;

		public CourseName(string value) : base(value)
		{
			if (value.Length < MIN_LENGTH)
			{
				throw InvalidAttributeException.FromMinLength("name", MIN_LENGTH);
			}

			if (value.Length > MAX_LENGTH)
			{
				throw InvalidAttributeException.FromMaxLength("name", MAX_LENGTH);
			}
		}
	}
}
