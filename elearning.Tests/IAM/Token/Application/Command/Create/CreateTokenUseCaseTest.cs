using System.Collections.Generic;
using elearning.src.IAM.Token.Application.Command.Create;
using elearning.src.IAM.Token.Domain;
using TokenAggregate = elearning.src.IAM.Token.Domain.Token;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.Tests.IAM.Token.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.Token.Application.Command.Create
{
    [TestFixture]
    public class CreateTokenUseCaseTest
    {
        private TokenHash hash;
        private TokenUserId userId;

        [SetUp]
        public void Setup()
        {
            hash = TokenHashStub.ByDefault();
            userId = TokenUserIdStub.ByDefault();
        }

        [Test]
        public void ItShouldCreateToken()
        {
            Mock<ITokenRepository> tokenRepository = CreatedAtAndSetupTokenRepositoryMock();
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();

            CreateTokenUseCase createTokenUseCase = new CreateTokenUseCase(
                tokenRepository.Object, eventProvider.Object
            );
            createTokenUseCase.Invoke(
                hash, userId
            );

            tokenRepository.Verify(
                m => m.Add(It.IsAny<TokenAggregate>()),
                Times.AtLeastOnce()
            );
        }

        [Test]
        public void ItShouldRecordReleasedTokenEvents()
        {
            Mock<ITokenRepository> tokenRepository = CreatedAtAndSetupTokenRepositoryMock();
            Mock<IEventProvider> eventProvider = CreateAndSetupEventProviderMock();

            CreateTokenUseCase createTokenUseCase = new CreateTokenUseCase(
                tokenRepository.Object, eventProvider.Object
            );
            createTokenUseCase.Invoke(
                hash, userId
            );

            eventProvider.Verify(
                m => m.RecordEvents(It.IsAny<List<DomainEvent>>()),
                Times.AtLeastOnce()
            );
        }

        private Mock<ITokenRepository> CreatedAtAndSetupTokenRepositoryMock()
        {
            Mock<ITokenRepository> tokenRepository = new Mock<ITokenRepository>();
            tokenRepository.Setup(m => m.Add(It.IsAny<TokenAggregate>())).Verifiable();
            return tokenRepository;
        }

        private Mock<IEventProvider> CreateAndSetupEventProviderMock()
        {
            Mock<IEventProvider> eventProvider = new Mock<IEventProvider>();
            eventProvider.Setup(m => m.RecordEvents(It.IsAny<List<DomainEvent>>())).Verifiable();
            return eventProvider;
        }
    }
}
