using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Bus.Query;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.FindUserByCredentials
{

    public class FindUserByCredentialsUseCase
    {

        private readonly IUserRepository userRepository;
        private readonly UserResponseForTokenConverter userResponseConverter;

        public FindUserByCredentialsUseCase(
            IUserRepository userRepository,
            UserResponseForTokenConverter userResponseConverter
        )
        {
            this.userRepository = userRepository;
            this.userResponseConverter = userResponseConverter;
        }

        public virtual IResponse Invoke(
            UserEmail email,
            UserHashedPassword password
        )
        {
            UserAggregate user = userRepository.FindByEmailAndPassword(email, password);

            return userResponseConverter.Convert(user);
        }
    }
}
