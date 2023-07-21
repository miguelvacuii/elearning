using elearning.src.IAM.Token.Infrastructure.Service.Token;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.Tests.IAM.Token.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.Token.Infrastructure.Service.Token
{
    [TestFixture]
    public class TokenFacadeTest
    {

        [Test]
        public void ItShouldCallQueryBusAndFindPayloadByEmailAndPassword()
        {
            string email = "example@example.com";
            string password = "1234";
            UserResponseForTokenTests expectedResponse = UserResponseForTokenStub.ByDefault();
            Mock<IQueryBus> queryBus = new Mock<IQueryBus>();
            queryBus.Setup(
                m => m.Ask(It.IsAny<IQuery>())
            ).Returns(expectedResponse);

            TokenFacade tokenFacade = new TokenFacade(queryBus.Object);
            IResponse response = tokenFacade.FindPayloadByEmailAndPassword(email, password);

            queryBus.VerifyAll();
            Assert.AreEqual(expectedResponse, response);
        }
    }
}
