using elearning.src.Shared.Domain.Specification;
using EnrollmentAggregate = elearning.src.StudentParticipation.Enrollment.Domain.Enrollment;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public interface ISpecification
    {
        ISpecification<EnrollmentAggregate> Create();
    }
}
