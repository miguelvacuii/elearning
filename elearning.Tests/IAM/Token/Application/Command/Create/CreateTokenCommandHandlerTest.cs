using elearning.src.IAM.Token.Application.Command.Create;
using elearning.src.IAM.Token.Domain;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.Tests.IAM.Token.Domain.Stub;
using Moq;
using NUnit.Framework;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;
using elearning.src.IAM.Token.Infrastructure.Service.Token;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.Tests.IAM.Token.Application.Command.Create
{
    [TestFixture]
    public class CreateTokenCommandHandlerTest
    {
        private CreateTokenCommand createTokenCommand;

        [SetUp]
        public void Setup()
        {
            TokenHash hash = TokenHashStub.ByDefault();
            TokenUserId userId = TokenUserIdStub.ByDefault();

            createTokenCommand = new CreateTokenCommand(
                hash.Value, userId.Value
            );
        }

        [Test]
        public void ItShouldFindPayloadByEmailAndPassword()
        {
            Mock<ITokenRepository> tokenRepository = new Mock<ITokenRepository>();
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<TokenAdapter> tokenAdapter = CreateAndSetupTokenAdapterMock();
            Mock<IJWTEncoder> jwtEncoder = new Mock<IJWTEncoder>();

            Mock<CreateTokenUseCase> createTokenUseCase = CreateAndSetupCreateTokenUseCaseMock(
                tokenRepository, eventProvider
            );

            CreateTokenCommandHandler createTokenCommandHandler = new CreateTokenCommandHandler(
                tokenAdapter.Object, jwtEncoder.Object, createTokenUseCase.Object
            );
            createTokenCommandHandler.Handle(createTokenCommand);

            tokenAdapter.Verify(
                m => m.FindPayloadByEmailAndPassword(It.IsAny<string>(), It.IsAny<string>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldInvokeUseCase()
        {
            Mock<ITokenRepository> tokenRepository = new Mock<ITokenRepository>();
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            Mock<TokenAdapter> tokenAdapter = CreateAndSetupTokenAdapterMock();
            Mock<IJWTEncoder> jwtEncoder = new Mock<IJWTEncoder>();

            Mock<CreateTokenUseCase> createTokenUseCase = CreateAndSetupCreateTokenUseCaseMock(
                tokenRepository, eventProvider
            );

            CreateTokenCommandHandler createTokenCommandHandler = new CreateTokenCommandHandler(
                tokenAdapter.Object, jwtEncoder.Object, createTokenUseCase.Object
            );
            createTokenCommandHandler.Handle(createTokenCommand);

            createTokenUseCase.VerifyAll();
        }

        private Mock<CreateTokenUseCase> CreateAndSetupCreateTokenUseCaseMock(
            Mock<ITokenRepository> tokenRepository,
            Mock<IEventProvider> eventProvider
        )
        {
            Mock<CreateTokenUseCase> createTokenUseCase = new Mock<CreateTokenUseCase>(
                tokenRepository.Object, eventProvider.Object
            );
            createTokenUseCase.Setup(m => m.Invoke(
                It.IsAny<TokenHash>(),
                It.IsAny<TokenUserId>()
            )).Verifiable();
            return createTokenUseCase;
        }

        private Mock<TokenAdapter> CreateAndSetupTokenAdapterMock()
        {
            Payload payload = PayloadStub.ByDefault();
            Mock<IQueryBus> queryBus = new Mock<IQueryBus>();
            UserResponseForTokenTests response = UserResponseForTokenStub.ByDefault();

            Mock<TokenFacade> tokenFacade = new Mock<TokenFacade>(queryBus.Object);
            tokenFacade.Setup(m => m.FindPayloadByEmailAndPassword(
                It.IsAny<string>(), It.IsAny<string>())
            ).Returns(response);

            Mock<TokenTranslator> tokenTranslator = new Mock<TokenTranslator>();
            tokenTranslator.Setup(m => m.FromRepresentationToPayload(It.IsAny<object>())).Returns(payload);

            Mock<TokenAdapter> tokenAdapter = new Mock<TokenAdapter>(tokenFacade.Object, tokenTranslator.Object);
            tokenAdapter.Setup(m => m.FindPayloadByEmailAndPassword(
                It.IsAny<string>(), It.IsAny<string>())
            ).Returns(payload);
            return tokenAdapter;
        }
    }
}
