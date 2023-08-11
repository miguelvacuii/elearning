using elearning.src.CourseBackoffice.Domain;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Infrastructure.Persistence.Repository
{
    public class CourseRepository : EntityFrameworkRepository<CourseAggregate>, ICourseRepository
    {
        public CourseRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
            : base(context, scopeFactory) { }
    }
}
