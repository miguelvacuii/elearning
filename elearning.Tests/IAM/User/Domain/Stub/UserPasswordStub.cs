using elearning.src.IAM.User.Domain;

namespace elearning.Tests.IAM.User.Domain.Stub
{
    public class UserPasswordStub {

        public static UserPassword ByDefault() {
            return new UserPassword("12345678");
        }

        public static UserPassword FromValue(string value) {
            return new UserPassword(value);
        }
    }
}
