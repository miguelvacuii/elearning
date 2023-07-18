using elearning.src.IAM.User.Domain;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Service.Hashing;

namespace elearning.src.IAM.User.Application.Query.FindUserByCredentials
{
    public class FindUserByCredentialsQueryHandler : IQueryHandler
    {
        private readonly IHashing hashing;
        private readonly FindUserByCredentialsUseCase findUserByCredentialsUseCase;

        public FindUserByCredentialsQueryHandler(
            IHashing hashing,
            FindUserByCredentialsUseCase findUserByCredentialsUseCase
        )
        {
            this.hashing = hashing;
            this.findUserByCredentialsUseCase = findUserByCredentialsUseCase;
        }

        public IResponse Handle(IQuery query)
        {
            FindUserByCredentialsQuery signUpUserCommand = query as FindUserByCredentialsQuery;
            HashedPassword hashedPassword = hashing.Hash(signUpUserCommand.password);

            UserEmail email = new UserEmail(signUpUserCommand.email);
            UserHashedPassword password = new UserHashedPassword(
                hashedPassword.Value
            );

            return findUserByCredentialsUseCase.Invoke(email, password);
        }
    }
}
