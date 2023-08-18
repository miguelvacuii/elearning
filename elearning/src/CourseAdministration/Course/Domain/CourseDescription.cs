using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.CourseAdministration.Course.Domain
{
    public class CourseDescription : StringValueObject
	{
		public const int MIN_LENGTH = 10;
		public const int MAX_LENGTH = 100;

		public CourseDescription(string value) : base(value)
		{
			if (value.Length < MIN_LENGTH)
			{
				throw InvalidAttributeException.FromMinLength("description", MIN_LENGTH);
			}

			if (value.Length > MAX_LENGTH)
			{
				throw InvalidAttributeException.FromMaxLength("description", MAX_LENGTH);
			}
		}
	}
}
