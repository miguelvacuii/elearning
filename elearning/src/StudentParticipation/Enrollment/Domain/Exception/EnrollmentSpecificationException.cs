using elearning.src.Shared.Domain.Exception;

namespace elearning.src.StudentParticipation.Enrollment.Domain.Exception
{
    public class EnrollmentSpecificationException : ResourceNotFoundException
	{
		public EnrollmentSpecificationException(string message) : base(message) { }

		public static EnrollmentSpecificationException FromCreation(
			EnrollmentCourseId courseId,
			EnrollmentStudentId studentId
		) {
			return new EnrollmentSpecificationException(
				string.Format(
					"Cannot create an enrollment with this courseId {0} and this studentId {1}",
					courseId.Value,
					studentId.Value
				)
			);
		}
	}
}
