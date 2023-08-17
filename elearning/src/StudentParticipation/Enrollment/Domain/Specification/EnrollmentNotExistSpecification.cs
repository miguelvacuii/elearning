using elearning.src.Shared.Domain.Specification;

namespace elearning.src.StudentParticipation.Enrollment.Domain.Specification
{
    public class EnrollmentNotExistSpecification : SpecificationBase<Enrollment>
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentNotExistSpecification(IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }

        public override bool IsSatisfiedBy(Enrollment candidate)
        {
            Enrollment enrollment = enrollmentRepository.Get(candidate.id);
            return enrollment == null;
        }
    }
}