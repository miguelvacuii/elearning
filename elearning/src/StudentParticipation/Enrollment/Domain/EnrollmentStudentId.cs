using elearning.src.Shared.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class EnrollmentStudentId : UUID
	{
		public EnrollmentStudentId(string value) : base(value) { }
	}
}
