using elearning.src.IAM.User.Application.Command.Update;
using elearning.src.IAM.User.Domain.Exception;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Command.Update
{
    [TestFixture]
    public class UpdateUserAuthorizationTest
    {

        [Test]
        public void ItShouldThrowExceptionWhenUserIdNotMatchWithQuery()
        {
            UpdateUserCommand query = new UpdateUserCommand(
                "544d2f5f-61b4-4532-b2e5-f96da15c102e",
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value
            );
            AuthUser authUser = CreateAuthUser();
            Mock<OAuth> oAuth = SetupOAuthFromAuthUser(authUser);
            string message = string.Format(
                "Auth user id does not match with this id {0}",
                query.id
            );
            UpdateUserAuthorization updateUserAuthorization = new UpdateUserAuthorization(oAuth.Object);

            UserAuthorizationException exception = Assert.Throws<UserAuthorizationException>(
                () => updateUserAuthorization.Authorize(query)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        private AuthUser CreateAuthUser()
        {
            return new AuthUser(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.ByDefault().Value
            );
        }

        private Mock<OAuth> SetupOAuthFromAuthUser(AuthUser authUser)
        {
            Mock<IJWTDecoder> decoder = new Mock<IJWTDecoder>();
            Mock<OAuth> oAuth = new Mock<OAuth>(decoder.Object);
            oAuth.Setup(m => m.User()).Returns(authUser);
            return oAuth;
        }
    }
}
