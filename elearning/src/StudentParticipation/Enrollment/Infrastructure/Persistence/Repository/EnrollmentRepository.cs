using elearning.src.StudentParticipation.Enrollment.Domain;
using EnrollmentAggregate = elearning.src.StudentParticipation.Enrollment.Domain.Enrollment;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Persistence.Repository
{
    public class EnrollmentRepository : EntityFrameworkRepository<EnrollmentAggregate>, IEnrollmentRepository
    {

        public EnrollmentRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
            : base(context, scopeFactory) { }
    }
}
