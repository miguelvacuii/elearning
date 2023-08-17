using elearning.src.Shared.Domain.Specification;
using elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment;

namespace elearning.src.StudentParticipation.Enrollment.Domain.Specification
{
    public class CourseExistSpecification : SpecificationBase<Enrollment>
    {
        private readonly EnrollmentAdapter enrollmentAdapter;

        public CourseExistSpecification(EnrollmentAdapter enrollmentAdapter)
        {
            this.enrollmentAdapter = enrollmentAdapter;
        }

        public override bool IsSatisfiedBy(Enrollment candidate)
        {
            Course course = enrollmentAdapter.FindCourseById(candidate.courseId.Value);
            return course != null;
        }
    }
}
