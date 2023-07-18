using elearning.src.IAM.Token.Domain;
using TokenAggregate = elearning.src.IAM.Token.Domain.Token;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.Token.Infrastructure.Persistence.Repository
{
    public class TokenRepository : EntityFrameworkRepository<TokenAggregate>, ITokenRepository
    {

        public TokenRepository(ELearningContext context, IServiceScopeFactory scopeFactory)
            : base(context, scopeFactory) { }
    }
}
