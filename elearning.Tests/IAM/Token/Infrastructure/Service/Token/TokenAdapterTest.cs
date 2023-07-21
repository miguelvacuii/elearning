using elearning.src.IAM.Token.Domain;
using elearning.src.IAM.Token.Infrastructure.Service.Token;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.Tests.IAM.Token.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.Token.Infrastructure.Service.Token
{
    [TestFixture]
    public class TokenAdapterTest
    {

        [Test]
        public void ItShouldCallCollaboratorsAndFindPayloadByEmailAndPassword()
        {
            string email = "example@example.com";
            string password = "1234";
            Payload expectedPayload = PayloadStub.ByDefault();
            UserResponseForTokenTests expectedResponse = UserResponseForTokenStub.ByDefault();
            Mock<IQueryBus> queryBus = new Mock<IQueryBus>();
            Mock<TokenFacade> tokenFacade = new Mock<TokenFacade>(queryBus.Object);
            tokenFacade.Setup(
                m => m.FindPayloadByEmailAndPassword(email, password)
            ).Returns(expectedResponse);
            Mock<TokenTranslator> tokenTranslator = new Mock<TokenTranslator>();
            tokenTranslator.Setup(
                m => m.FromRepresentationToPayload(It.IsAny<object>())
            ).Returns(expectedPayload);

            TokenAdapter tokenAdapter = new TokenAdapter(tokenFacade.Object, tokenTranslator.Object);
            Payload payload = tokenAdapter.FindPayloadByEmailAndPassword(email, password);

            tokenFacade.VerifyAll();
            tokenTranslator.VerifyAll();
            Assert.AreEqual(expectedPayload, payload);
        }
    }
}
