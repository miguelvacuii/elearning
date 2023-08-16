using elearning.src.Shared.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class EnrollmentId : UUID
	{
		public EnrollmentId(string value) : base(value) { }
	}
}
