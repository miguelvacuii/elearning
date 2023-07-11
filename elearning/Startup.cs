using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Domain.Service;
using elearning.src.IAM.User.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Bus.Command;
using elearning.src.Shared.Infrastructure.Bus.Query;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Infrastructure.Service.Hashing;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            services.AddApiVersioning(config => {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddSwaggerGen(
                options => {

                    var provider = services.BuildServiceProvider()
                                        .GetRequiredService<IApiVersionDescriptionProvider>();

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


            // Shared / Domain
            services.AddScoped<ICommandBus, SyncCommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<UniqueUser>();

            // Shared / Infrastructure
            services.AddScoped<IHashing, DefaultHashing>();
            services.AddScoped<IJsonApiEncoder, JsonApiEncoder>();

            // IAM / User / Domain
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));


            // IAM / User / Appllication
            services.AddScoped<SignUpUserCommandHandler>();
            services.AddScoped<SignUpUserUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.Use((context, next) =>
            {
                ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();
                SignUpUserCommandHandler signUpUserCommandHandler = context.RequestServices.GetRequiredService<SignUpUserCommandHandler>();
                commandBus.Subscribe(signUpUserCommandHandler);

                return next();
            });


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
