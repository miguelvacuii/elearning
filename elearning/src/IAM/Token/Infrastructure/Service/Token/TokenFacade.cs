using elearning.src.IAM.User.Application.Query.FindUserByCredentials;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.Token.Infrastructure.Service.Token
{
    public class TokenFacade
    {
        private readonly IQueryBus queryBus;

        public TokenFacade(IQueryBus queryBus)
        {
            this.queryBus = queryBus;
        }

        public virtual IResponse FindPayloadByEmailAndPassword(string email, string password)
        {
            FindUserByCredentialsQuery findUserByCredentialsQuery = new FindUserByCredentialsQuery(email, password);
            return queryBus.Ask(findUserByCredentialsQuery);
        }
    }
}
