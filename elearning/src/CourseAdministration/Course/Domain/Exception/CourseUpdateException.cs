using System.ComponentModel.DataAnnotations;

namespace elearning.src.CourseAdministration.Course.Domain.Exception
{
    public class CourseUpdateException : ValidationException
    {
		public CourseUpdateException(string message) : base(message) { }

		public static CourseUpdateException FromUserId()
		{
			return new CourseUpdateException(
				"Auth user id not corresponding to teacherId in course"
			);
		}
	}
}
