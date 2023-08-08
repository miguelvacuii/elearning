using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Application.Event;
using elearning.src.IAM.User.Application.Query.FindByCriteria;
using elearning.src.IAM.User.Application.Query.FindById;
using elearning.src.IAM.User.Application.Query.FindUserByCredentials;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using elearning.src.Shared.Infrastructure.Security.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.User.Infrastructure.Framework.Configure.Startup.Service
{
    public class ApplicationServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<SignUpUserCommandHandler>();
            services.AddScoped<SignUpUserUseCase>();
            services.AddScoped<SendWelcomeEmailWhenUserSignedUpEventHandler>();

            services.AddScoped<FindUserByCredentialsQueryHandler>();
            services.AddScoped<FindUserByCredentialsUseCase>();
            services.AddScoped<UserResponseForTokenConverter>();

            services.AddScoped<FindUsersByCriteriaQueryHandler>();
            services.AddScoped<FindUsersByCriteriaUseCase>();
            services.AddScoped<UserListResponseConverter>();

            services.AddScoped<IAuthorization, FindUserByIdAuthorization>();
            services.AddScoped<FindUserByIdQueryHandler>();
            services.AddScoped<FindUserByIdUseCase>();
            services.AddScoped<UserResponseConverter>();
        }
    }
}
