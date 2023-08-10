using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;
using elearning.Tests.IAM.User.Domain.Stub;
using NUnit.Framework;

namespace elearning.Tests.Shared.Domain
{
    [TestFixture]
    public class AuthUserTest
    {
        private AuthUser authUser;

        [Test]
        public void ItShouldReturnTrueIfRoleIsStudent()
        {
            authUser = CreateAuthUser(AuthUser.ROLE_STUDENT);
            Assert.True(authUser.IsStudent());
        }

        [Test]
        public void ItShouldReturnTrueIfRoleIsTeacher()
        {
            authUser = CreateAuthUser(AuthUser.ROLE_TEACHER);
            Assert.True(authUser.IsTeacher());
        }

        [Test]
        public void ItShouldReturnTrueIfRoleIsAdministrator()
        {
            authUser = CreateAuthUser(AuthUser.ROLE_ADMINISTRATOR);
            Assert.True(authUser.IsAdministrator());
        }

        [Test]
        [TestCase(AuthUser.ROLE_STUDENT)]
        [TestCase(AuthUser.ROLE_TEACHER)]
        [TestCase(AuthUser.ROLE_ADMINISTRATOR)]
        public void ItShouldReturnTrueIfRoleIsContainInRoleList(string role)
        {
            Assert.True(AuthUser.Contains(role));
        }

        [Test]
        public void ItShouldReturnFalseIfRoleIsNotContainInRoleList()
        {
            Assert.False(AuthUser.Contains("role"));
        }

        private AuthUser CreateAuthUser(string role)
        {
            return new AuthUser(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.FromValue(role).Value
            );
        }
    }
}
