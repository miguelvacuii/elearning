using elearning.src.IAM.Token.Domain;
using elearning.src.IAM.Token.Infrastructure.Service.Token;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;

namespace elearning.src.IAM.Token.Application.Command.Create
{
    public class CreateTokenCommandHandler : ICommandHandler
    {
        private readonly TokenAdapter tokenAdapter;
        private readonly IJWTEncoder jwtEncoder;
        private readonly CreateTokenUseCase createTokenUseCase;

        public CreateTokenCommandHandler(
            TokenAdapter tokenAdapter,
            IJWTEncoder jwtEncoder,
            CreateTokenUseCase createTokenUseCase
        )
        {
            this.tokenAdapter = tokenAdapter;
            this.jwtEncoder = jwtEncoder;
            this.createTokenUseCase = createTokenUseCase;
        }

        public void Handle(ICommand command)
        {
            CreateTokenCommand createTokenCommand = command as CreateTokenCommand;

            Payload payload = tokenAdapter.FindPayloadByEmailAndPassword(createTokenCommand.email, createTokenCommand.password);
            string hash = jwtEncoder.Encode(payload);
            TokenHash tokenHash = new TokenHash(hash);
            TokenUserId tokenUserId = new TokenUserId(payload.userId);

            createTokenUseCase.Invoke(tokenHash, tokenUserId);
        }
    }
}
