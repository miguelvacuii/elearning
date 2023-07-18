using elearning.src.IAM.Token.Domain;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.IAM.Token.Infrastructure.Service.Token
{
    public class TokenAdapter
    {
        private readonly TokenFacade tokenFacade;
        private readonly TokenTranslator tokenTranslator;

        public TokenAdapter(
            TokenFacade tokenFacade,
            TokenTranslator tokenTranslator
        )
        {
            this.tokenFacade = tokenFacade;
            this.tokenTranslator = tokenTranslator;
        }

        public Payload FindPayloadByEmailAndPassword(string email, string password)
        {
            IResponse response = tokenFacade.FindPayloadByEmailAndPassword(email, password);
            return tokenTranslator.FromRepresentationToPayload(response);
        }
    }
}
