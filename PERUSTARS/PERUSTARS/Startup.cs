using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;

using PERUSTARS.AtEventManagement.Application.artevents.service;
using PERUSTARS.AtEventManagement.Domain.Model.Repositories;
using PERUSTARS.AtEventManagement.Domain.Services.ArtEvent;
using PERUSTARS.AtEventManagement.Infrastructure;
using PERUSTARS.AtEventManagement.Application;
using System.Reflection;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Http;
using PERUSTARS.AtEventManagement.Application.Participant.Queries;
using PERUSTARS.AtEventManagement.Domain.Services.Participant;
using Microsoft.AspNetCore.Http;
using PERUSTARS.ArtworkManagement.Infrastructure.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Application.Settings;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Infrastructure.Repositories;
using PERUSTARS.ProfileManagement.Domain.Persistence;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using PERUSTARS.Shared.Profiles;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PERUSTARS.IdentityAndAccountManagement.Application.Commands.Services;
using PERUSTARS.IdentityAndAccountManagement.Application.Middleware;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services;

namespace PERUSTARS
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
            //Add CORS Support
            services.AddCors();

            services.AddControllers();

            //AppSettings Section Reference
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //JSON Web Token Authentication Configuration
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Authentication Service Configuration
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

            //Database

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Dependency Injection Configuration
            services.Configure<ExceptionHandlerOptions>(options => {
                options.ExceptionHandler = default;
                options.ExceptionHandlingPath = PathString.FromUriComponent("/error");
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IArtEventRepository, ArtEventRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddScoped<IArtEventCommandService, ArtEventService>();
            services.AddScoped<IArtEventQueryService, ArtEventQueryService>();
            services.AddScoped<IParticipantQueryService, ParticipantQueryService>();

            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityAndAccountManagementCommandService, IdentityAndAccountManagementCommandService>();

            // Apply Endpoints Naming Convention
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.Configure<ExceptionHandlerOptions>(options => {
                options.ExceptionHandler = default;
                options.ExceptionHandlingPath = PathString.FromUriComponent("/error");
            });

            // AutoMapper Setup
            services.AddAutoMapper(typeof(ModelToResourceProfile),
                typeof(CommandToModelProfile),
                typeof(ResourceToCommandProfile),
                typeof(ResourceToModelProfile));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PERUSTARS", Version = "v1" });
                c.EnableAnnotations();
            });
            
            
        }

      


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PERUSTARS v1"));
                      
            

            app.UseHttpsRedirection();

            app.UseRouting();

            // CORS Configuration
            app.UseCors(x => x.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            //Authentication Support
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMiddleware<JwtMiddleware>();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}