using System;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.CourseBackoffice.Domain
{
    public class CourseStatus : StringValueObject
	{
		public CourseStatus(string value) : base(value)
		{
			if (!Enum.IsDefined(typeof(CourseStatusEnum), value))
			{
				throw InvalidAttributeException.FromText("This status is not correct");
			}
		}
	}
}
