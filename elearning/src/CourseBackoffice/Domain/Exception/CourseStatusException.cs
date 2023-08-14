using System.ComponentModel.DataAnnotations;

namespace elearning.src.CourseBackoffice.Domain.Exception
{
    public class CourseStatusException : ValidationException
    {
		public CourseStatusException(string message) : base(message) { }

		public static CourseStatusException FromPublish(CourseStatus status)
		{
			return new CourseStatusException(
				string.Format("Cannot publish this course because status is {0}", status.Value)
			);
		}
	}
}
