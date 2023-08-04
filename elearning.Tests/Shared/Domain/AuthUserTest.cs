using elearning.src.Shared.Domain;
using elearning.Tests.IAM.User.Domain.Stub;
using NUnit.Framework;

namespace elearning.Tests.Shared.Domain
{
    [TestFixture]
    public class AuthUserTest
    {

        [Test]
        public void ItShouldReturnTrueIfRoleIsStudent()
        {
            AuthUser authUser = new AuthUser(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.FromValue("student").Value
            );
            Assert.True(authUser.IsStudent());
        }

        [Test]
        public void ItShouldReturnTrueIfRoleIsTeacher()
        {
            AuthUser authUser = new AuthUser(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.FromValue("teacher").Value
            );
            Assert.True(authUser.IsTeacher());
        }

        [Test]
        public void ItShouldReturnTrueIfRoleIsAdministrator()
        {
            AuthUser authUser = new AuthUser(
                UserIdStub.ByDefault().Value,
                UserEmailStub.ByDefault().Value,
                UserFirstNameStub.ByDefault().Value,
                UserLastNameStub.ByDefault().Value,
                UserRoleStub.FromValue("administrator").Value
            );
            Assert.True(authUser.IsAdministrator());
        }
    }
}
