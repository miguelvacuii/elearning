using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.IAM.User.Application.Query.Exception;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.User.Application.Query.FindById
{
    public class FindUserByIdUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly UserResponseConverter userResponseConverter;

        public FindUserByIdUseCase(
            IUserRepository userRepository,
            UserResponseConverter userResponseConverter
        ) {
            this.userRepository = userRepository;
            this.userResponseConverter = userResponseConverter;
        }

        internal IResponse Invoke(UserId userId)
        {
            UserAggregate user = userRepository.Get(userId);
            if (user == null) {
                throw UserNotFoundException.FromId(userId);
            }
            return userResponseConverter.Convert(user);
        }
    }
}