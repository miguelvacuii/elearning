using elearning.src.Shared.Domain.Specification;
using elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment;

namespace elearning.src.StudentParticipation.Enrollment.Domain.Specification
{
    public class CreateEnrollmentSpecificationFactory : ISpecification
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly EnrollmentAdapter enrollmentAdapter;

        public CreateEnrollmentSpecificationFactory(
            IEnrollmentRepository enrollmentRepository,
            EnrollmentAdapter enrollmentAdapter
        ) {
            this.enrollmentRepository = enrollmentRepository;
            this.enrollmentAdapter = enrollmentAdapter;
        }

        public ISpecification<Enrollment> Create()
        {
            CourseExistSpecification courseExistSpecification = new CourseExistSpecification(enrollmentAdapter);
            StudentExistSpecification studentExistSpecification = new StudentExistSpecification(enrollmentAdapter);
            EnrollmentNotExistSpecification enrollmentNotExistSpecification = new EnrollmentNotExistSpecification(enrollmentRepository);

            return courseExistSpecification.And(studentExistSpecification.And(enrollmentNotExistSpecification));
        }
    }
}
