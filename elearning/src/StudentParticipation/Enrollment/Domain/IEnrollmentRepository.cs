using elearning.src.Shared.Infrastructure.Persistence.Repository;
using elearning.src.StudentParticipation.Enrollment.Domain;

namespace elearning.src.CourseBackoffice.Domain
{
    public interface IEnrollmentRepository : IRepository<Enrollment> { }
}
