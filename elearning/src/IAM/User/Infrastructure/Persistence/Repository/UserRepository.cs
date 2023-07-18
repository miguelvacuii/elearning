using System.Linq;
using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.IAM.User.Infrastructure.Persistence.Repository
{
    public class UserRepository : EntityFrameworkRepository<UserAggregate>, IUserRepository
    {
        public UserRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
            : base(context, scopeFactory) { }
        public virtual UserAggregate FindByEmail(UserEmail email)
        {
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ELearningContext>();
                IQueryable<UserAggregate> query = dbContext.Set<UserAggregate>();
                return query.FirstOrDefault(c => c.email.Value == email.Value);
            }
        }

        public virtual UserAggregate FindByEmailAndPassword(UserEmail userEmail, UserHashedPassword userPassword)
        {
            UserAggregate user = FindByEmail(userEmail);

            if (!userPassword.Equals(user.password))
            {
                throw InvalidAttributeException.FromText("Password are not equals");
            }

            return user;
        }
    }
}
