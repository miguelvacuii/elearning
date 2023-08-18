using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            (new src.Shared.Infrastructure.Framework.Startup.Service.SwaggerService()).Load(services);
            (new src.Shared.Infrastructure.Framework.Startup.Service.MySqlService(Configuration)).Load(services);
            (new src.Shared.Infrastructure.Framework.Startup.Service.AuthenticationService(Configuration)).Load(services);
            (new src.Shared.Infrastructure.Framework.Startup.Service.InfrastructureServices()).Load(services);

            (new src.IAM.User.Infrastructure.Framework.Configure.Startup.Service.ApplicationServices()).Load(services);
            (new src.IAM.User.Infrastructure.Framework.Configure.Startup.Service.DomainServices()).Load(services);
            (new src.IAM.User.Infrastructure.Framework.Configure.Startup.Service.InfrastructureServices()).Load(services);

            (new src.IAM.Token.Infrastructure.Framework.Configure.Startup.Service.InfrastructureServices()).Load(services);
            (new src.IAM.Token.Infrastructure.Framework.Configure.Startup.Service.DomainServices()).Load(services);
            (new src.IAM.Token.Infrastructure.Framework.Configure.Startup.Service.ApplicationServices()).Load(services);

            (new src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Service.InfrastructureServices()).Load(services);
            (new src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Service.DomainServices()).Load(services);
            (new src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Service.ApplicationServices()).Load(services);

            (new src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Service.InfrastructureServices()).Load(services);
            (new src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Service.DomainServices()).Load(services);
            (new src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Service.ApplicationServices()).Load(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.Use((context, next) =>
            {
                (new src.Shared.Infrastructure.Framework.Startup.Subscriber.SyncCommandBusSubscriber()).Setup(context);
                (new src.Shared.Infrastructure.Framework.Startup.Subscriber.QueryBusSubscriber()).Setup(context);

                (new src.IAM.User.Infrastructure.Framework.Configure.Startup.Subscriber.SyncCommandSubscriber()).Setup(context);
                (new src.IAM.User.Infrastructure.Framework.Configure.Startup.Subscriber.QueryBusSubscriber()).Setup(context);
                (new src.IAM.User.Infrastructure.Framework.Configure.Startup.Subscriber.SyncEventSubscriber()).Setup(context);

                (new src.IAM.Token.Infrastructure.Framework.Configure.Startup.Subscriber.SyncCommandSubscriber()).Setup(context);
                (new src.IAM.Token.Infrastructure.Framework.Configure.Startup.Subscriber.SyncEventSubscriber()).Setup(context);

                (new src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Subscriber.SyncCommandSubscriber()).Setup(context);
                (new src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Subscriber.QueryBusSubscriber()).Setup(context);
                (new src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Subscriber.SyncEventSubscriber()).Setup(context);

                (new src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Subscriber.SyncCommandSubscriber()).Setup(context);
                (new src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Subscriber.SyncEventSubscriber()).Setup(context);

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
