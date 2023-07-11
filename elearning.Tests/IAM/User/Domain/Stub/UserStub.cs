using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.Tests.IAM.User.Domain.Stub
{
    public class UserStub {

        public static UserAggregate ByDefault() {
            return UserAggregate.SignUp(
                UserIdStub.ByDefault(),
                UserEmailStub.ByDefault(),
                UserFirstNameStub.ByDefault(),
                UserLastNameStub.ByDefault(),
                UserHashedPasswordStub.ByDefault(),
                UserRoleStub.ByDefault()
            );
        }

        public static UserAggregate FromValues(
            string id = "",
            string email = "",
            string password = "",
            string firstName = "",
            string lastName = "",
            string role = ""
        ) {
            return UserAggregate.SignUp(
                string.IsNullOrEmpty(id) ? UserIdStub.ByDefault() : UserIdStub.FromValue(id),
                string.IsNullOrEmpty(email) ? UserEmailStub.ByDefault() : UserEmailStub.FromValue(email),
                string.IsNullOrEmpty(firstName) ? UserFirstNameStub.ByDefault() : UserFirstNameStub.FromValue(firstName),
                string.IsNullOrEmpty(lastName) ? UserLastNameStub.ByDefault() : UserLastNameStub.FromValue(lastName),
                string.IsNullOrEmpty(password) ? UserHashedPasswordStub.ByDefault() : UserHashedPasswordStub.FromValue(password),
                string.IsNullOrEmpty(role) ? UserRoleStub.ByDefault() : UserRoleStub.FromValue(role)
            );
        }
    }
}

