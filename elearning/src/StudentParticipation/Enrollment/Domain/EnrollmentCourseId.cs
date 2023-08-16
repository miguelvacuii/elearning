using elearning.src.Shared.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class EnrollmentCourseId : UUID
	{
		public EnrollmentCourseId(string value) : base(value) { }
	}
}
