using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Domain.Exception;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;
using elearning.src.Shared.Infrastructure.Security.Authorization.Exception;
using elearning.Tests.IAM.User.Domain.Stub;
using Moq;
using NUnit.Framework;

namespace elearning.Tests.IAM.User.Application.Query.FindUserById
{
    [TestFixture]
    public class FindUserByIdAuthorizationTest
    {

        [Test]
        public void ItShouldThrowExceptionWhenRoleIsNotStudent() {
            FindUserByIdQuery query = new FindUserByIdQuery(UserIdStub.ByDefault().Value);
            AuthUser authUser = CreateAuthUser("administrator");
            Mock<OAuth> oAuth = SetupOAuthFromAuthUser(authUser);
            string message = string.Format(
                "Unauthorized get resource from this role {0}",
                authUser.role
            );

            FindUserByIdAuthorization findUserByIdAuthorization = new FindUserByIdAuthorization(oAuth.Object);

            UnauthorizedException exception = Assert.Throws<UnauthorizedException>(
                () => findUserByIdAuthorization.Authorize(query)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        [Test]
        public void ItShouldThrowExceptionWhenUserIdNotMatchWithQuery()
        {
            FindUserByIdQuery query = new FindUserByIdQuery("544d2f5f-61b4-4532-b2e5-f96da15c102e");
            AuthUser authUser = CreateAuthUser("student");
            Mock<OAuth> oAuth = SetupOAuthFromAuthUser(authUser);
            string message = string.Format(
                "Auth user id does not match with this id {0}",
                query.id
            );
            FindUserByIdAuthorization findUserByIdAuthorization = new FindUserByIdAuthorization(oAuth.Object);

            UserAuthorizationException exception = Assert.Throws<UserAuthorizationException>(
                () => findUserByIdAuthorization.Authorize(query)
            );

            Assert.That(exception.Message, Is.EqualTo(message));
        }

        private AuthUser CreateAuthUser(string role) {
            return new AuthUser(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.FromValue(role).Value
            );
        }

        private Mock<OAuth> SetupOAuthFromAuthUser(AuthUser authUser) {
            Mock<IJWTDecoder> decoder = new Mock<IJWTDecoder>();
            Mock<OAuth> oAuth = new Mock<OAuth>(decoder.Object);
            oAuth.Setup(m => m.User()).Returns(authUser);
            return oAuth;
        }
    }
}
