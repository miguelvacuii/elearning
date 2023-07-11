using elearning.src.Shared.Domain;
using NUnit.Framework;

namespace elearning.Tests.Shared.Domain
{
    public class AuthUserTest
    {
        [Test]
        public void ItShouldReturnFalseIfRoleIsNotStudent()
        {
            Assert.False(AuthUser.IsStudent("role"));
        }

        [Test]
        public void ItShouldReturnFalseIfRoleIsNotTeacher()
        {
            Assert.False(AuthUser.IsTeacher("role"));
        }

        [Test]
        public void ItShouldReturnFalseIfRoleIsNotAdministrator()
        {
            Assert.False(AuthUser.IsAdministrator("role"));
        }
    }
}
