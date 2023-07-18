using System.Text;
using elearning.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.Shared.Infrastructure.Bus.Event;
using elearning.src.IAM.Token.Application.Command.Create;
using elearning.src.IAM.Token.Application.Event;
using elearning.src.IAM.Token.Domain;
using elearning.src.IAM.Token.Domain.Event;
using elearning.src.IAM.Token.Infrastructure.Persistence.Repository;
using elearning.src.IAM.Token.Infrastructure.Service.Token;
using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Application.Event;
using elearning.src.IAM.User.Application.Query.FindUserByCredentials;
using elearning.src.IAM.User.Application.Query.Response;
using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Event;
using elearning.src.IAM.User.Domain.Service;
using elearning.src.IAM.User.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Bus.Command;
using elearning.src.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.src.Shared.Infrastructure.Bus.Event;
using elearning.src.Shared.Infrastructure.Bus.Query;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;
using elearning.src.Shared.Infrastructure.Service.Hashing;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.Infrastructure.Service.Mailer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace elearning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Swagger
            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddSwaggerGen(
                options => {
                    options.AddSecurityDefinition("oauth2", new ApiKeyScheme
                    {
                        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                        In = "header",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                    options.OperationFilter<SecurityRequirementsOperationFilter>();

                    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new Info()
                            {
                                Title = $"Sample API {description.ApiVersion}",
                                Version = description.ApiVersion.ToString()
                            });
                    }
                }
            );



            // MySQL
            services.AddDbContextPool<ELearningContext>(options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
            );
            services.AddScoped<ELearningContext>();


            // Auth

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var secret = Configuration.GetValue<string>("AppSettings:Secret");
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddOptions();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Shared / Domain
            services.AddScoped<UniqueUser>();

            // Shared / Infrastructure
            services.AddScoped<ELearningContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddScoped<ICommandBus, SyncCommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBusSync>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisherSync>();
            services.AddScoped<IEventProvider, EventProvider>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped<EventDispatcherSyncMiddleware>();
            services.AddScoped<IHashing, DefaultHashing>();
            services.AddScoped<IMailer, Sendgrid>();
            services.AddScoped<IJsonApiEncoder, JsonApiEncoder>();
            services.AddScoped<IJWTEncoder, JWTEncoder>();
            services.AddScoped<IJWTDecoder, JWTDecoder>();


            // IAM / User / Infrastructure
            services.AddScoped<IUserRepository, UserRepository>();


            // IAM / User / Appllication
            services.AddScoped<SignUpUserCommandHandler>();
            services.AddScoped<SignUpUserUseCase>();
            services.AddScoped<SendWelcomeEmailWhenUserSignedUpEventHandler>();

            services.AddScoped<FindUserByCredentialsQueryHandler>();
            services.AddScoped<FindUserByCredentialsUseCase>();
            services.AddScoped<UserResponseForTokenConverter>();

            // IAM / Token / Domain
            services.AddScoped<TokenFacade>();
            services.AddScoped<TokenTranslator>();
            services.AddScoped<TokenAdapter>();

            // IAM / Token / Infrastructure
            services.AddScoped<ITokenRepository, TokenRepository>();

            // IAM / Token / Application
            services.AddScoped<CreateTokenCommandHandler>();
            services.AddScoped<CreateTokenUseCase>();
            services.AddScoped<SetTokenToHeaderWhenTokenCreatedHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.Use((context, next) =>
            {
                ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();

                SignUpUserCommandHandler signUpUserCommandHandler = context.RequestServices.GetRequiredService<SignUpUserCommandHandler>();
                commandBus.Subscribe(signUpUserCommandHandler);

                CreateTokenCommandHandler createTokenCommandHandler = context.RequestServices.GetRequiredService<CreateTokenCommandHandler>();
                commandBus.Subscribe(createTokenCommandHandler);

                commandBus.AddMiddleware(context.RequestServices.GetRequiredService<TransactionMiddleware>());

                commandBus.AddMiddleware(context.RequestServices.GetRequiredService<EventDispatcherSyncMiddleware>());

                IQueryBus queryBus = context.RequestServices.GetRequiredService<IQueryBus>();

                FindUserByCredentialsQueryHandler findUserByCredentialsQueryHandler = context.RequestServices.GetRequiredService<FindUserByCredentialsQueryHandler>();
                queryBus.Subscribe(findUserByCredentialsQueryHandler);

                IEventBus eventBus = context.RequestServices.GetRequiredService<IEventBus>();

                eventBus.Subscribe(
                    context.RequestServices.GetRequiredService<SendWelcomeEmailWhenUserSignedUpEventHandler>(),
                    UserSignedUpEvent.NAME
                );

                eventBus.Subscribe(
                    context.RequestServices.GetRequiredService<SetTokenToHeaderWhenTokenCreatedHandler>(),
                    TokenCreatedEvent.NAME
                );

                return next();
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });

            app.UseCors("AllowAllOrigins");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
        }
    }
}
