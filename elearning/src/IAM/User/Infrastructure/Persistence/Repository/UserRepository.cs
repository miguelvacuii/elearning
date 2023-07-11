using System.Linq;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.User.Infrastructure.Persistence.Repository
{
    public class UserRepository : EntityFrameworkRepository<Domain.User>, IUserRepository
    {
        public UserRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
            : base(context, scopeFactory) { }
        public virtual Domain.User FindByEmail(UserEmail email)
        {
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ELearningContext>();
                IQueryable<Domain.User> query = dbContext.Set<Domain.User>();
                return query.FirstOrDefault(c => c.email.Value == email.Value);
            }
        }
    }
}
