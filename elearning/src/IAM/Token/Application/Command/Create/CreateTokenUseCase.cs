using elearning.src.IAM.Token.Domain;
using elearning.src.Shared.Domain.Bus.Event;

namespace elearning.src.IAM.Token.Application.Command.Create
{
    public class CreateTokenUseCase
    {
        private readonly ITokenRepository tokenRepository;
        private readonly IEventProvider eventProvider;

        public CreateTokenUseCase(
            ITokenRepository tokenRepository,
            IEventProvider eventProvider
        )
        {
            this.tokenRepository = tokenRepository;
            this.eventProvider = eventProvider;
        }

        public void Invoke(
            TokenHash tokenHash,
            TokenUserId tokenUserId
        )
        {
            Domain.Token token = Domain.Token.Create(tokenHash, tokenUserId);
            tokenRepository.Add(token);
            eventProvider.RecordEvents(token.ReleaseEvents());
        }
    }
}

