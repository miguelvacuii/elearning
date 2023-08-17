using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.StudentParticipation.Enrollment.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment
{
    public class EnrollmentAdapter
    {
        private readonly EnrollmenrFacade enrollmenrFacade;
        private readonly EnrollmentTranslator enrollmentTranslator;

        public EnrollmentAdapter(
            EnrollmenrFacade enrollmenrFacade,
            EnrollmentTranslator enrollmentTranslator
        ) {
            this.enrollmenrFacade = enrollmenrFacade;
            this.enrollmentTranslator = enrollmentTranslator;
        }

        public Course FindCourseById(string id) {
            IResponse response = enrollmenrFacade.FindCourseById(id);
            return enrollmentTranslator.FromRepresentationToCourse(response);
        }

        public Student FindStudentById(string id)
        {
            IResponse response = enrollmenrFacade.FindStudentById(id);
            return enrollmentTranslator.FromRepresentationToStudent(response);
        }
    }
}
