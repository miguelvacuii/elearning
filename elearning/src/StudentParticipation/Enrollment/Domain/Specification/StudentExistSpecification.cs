using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Specification;
using elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment;

namespace elearning.src.StudentParticipation.Enrollment.Domain.Specification
{
    public class StudentExistSpecification : SpecificationBase<Enrollment>
    {
        private readonly EnrollmentAdapter enrollmentAdapter;

        public StudentExistSpecification(EnrollmentAdapter enrollmentAdapter)
        {
            this.enrollmentAdapter = enrollmentAdapter;
        }

        public override bool IsSatisfiedBy(Enrollment candidate)
        {
            Student student = enrollmentAdapter.FindStudentById(candidate.studentId.Value);
            return (student == null || student.role != AuthUser.ROLE_STUDENT) ? false : true;
        }
    }
}