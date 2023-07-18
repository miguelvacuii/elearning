using elearning.src.IAM.User.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.Token.Infrastructure.Service.Token
{
    public class TokenFacade {

        private readonly IUserRepository userRepository;

        public TokenFacade(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public UserAggregate FindPayloadByEmailAndPassword(string email, string password)
        {
            return userRepository.FindByEmail(new UserEmail(email));
        }
    }
}
