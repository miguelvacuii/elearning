using elearning.src.Shared.Domain;

namespace elearning.src.CourseAdministration.Course.Domain
{
    public class CourseId : UUID {
		public CourseId(string value) : base(value) {}
	}
}
