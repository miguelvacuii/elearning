using elearning.src.StudentParticipation.Enrollment.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment
{
    public class EnrollmentTranslator
    {
        public EnrollmentTranslator()
        {
        }

        internal Course FromRepresentationToCourse(dynamic response)
        {
            return new Course(
                response.id,
                response.name,
                response.description,
                response.status,
                response.teacherId
            );
        }

        internal Student FromRepresentationToStudent(dynamic response)
        {
            return new Student(
                response.id,
                response.email,
                response.firstName,
                response.lastName,
                response.role
            );
        }
    }
}
