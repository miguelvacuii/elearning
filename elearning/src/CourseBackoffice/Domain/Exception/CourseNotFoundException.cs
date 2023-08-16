using elearning.src.Shared.Domain.Exception;

namespace elearning.src.CourseBackoffice.Domain.Exception
{
    public class CourseNotFoundException : ResourceNotFoundException
    {
		public CourseNotFoundException(string message) : base(message) { }

		public static CourseNotFoundException FromId(CourseId id)
		{
			return new CourseNotFoundException(
				string.Format("Not found any course with this id {0}", id.Value)
			);
		}
	}
}
