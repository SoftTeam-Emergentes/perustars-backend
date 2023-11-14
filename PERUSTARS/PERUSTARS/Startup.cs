using System;
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
using Microsoft.AspNetCore.Http;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;
using PERUSTARS.IdentityAndAccountManagement.Infrastructure.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using PERUSTARS.Shared.Profiles;
using PERUSTARS.IdentityAndAccountManagement.Application.Commands.Services;
using PERUSTARS.IdentityAndAccountManagement.Application.Middleware;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Domain.Repositories;
using PERUSTARS.ArtworkManagement.Infrastructure.Repositories;
using PERUSTARS.ArtworkManagement.Domain.Services;
using PERUSTARS.ArtworkManagement.Application.Commands.Services;
using PERUSTARS.ProfileManagement.Infrastructure.Repositories;
using PERUSTARS.ProfileManagement.Domain.Repositories;
using PERUSTARS.ProfileManagement.Domain.Services;
using PERUSTARS.ProfileManagement.Application.Commands.Services;
using PERUSTARS.ConductsReportsManagement.Domain.Repositories;
using PERUSTARS.ConductsReportsManagement.Domain.Model.Services;
using PERUSTARS.ConductsReportsManagement.Infrastructure.Repository;
using PERUSTARS.ConductsReportsManagement.Application.Command.Services;
using MediatR;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using PERUSTARS.CommunicationAndNotificationManagement.Infraestructure.Repositories;
using PERUSTARS.CommunicationAndNotificationManagement.Application.Commands.Services;
using PERUSTARS.DataAnalytics.Interface.ACL;
using PERUSTARS.DataAnalytics.Domain.Repositories;
using PERUSTARS.DataAnalytics.Infrastructure.Repositories;
using PERUSTARS.DataAnalytics.Domain.Services;
using PERUSTARS.DataAnalytics.Application.Commands.Services;
using Microsoft.Extensions.Logging;
using PERUSTARS.ArtEventManagement.Application.ArtEvents.Service;
using PERUSTARS.ArtEventManagement.Application.Participant.Command.Service;
using PERUSTARS.ArtEventManagement.Application.Participant.Queries;
using PERUSTARS.ArtEventManagement.Domain.Model.Repositories;
using PERUSTARS.ArtEventManagement.Domain.Services.ArtEvent;
using PERUSTARS.ArtEventManagement.Domain.Services.Participant;
using PERUSTARS.ArtEventManagement.Infrastructure;
using PERUSTARS.DataAnalytics.Application.Jobs;
using PERUSTARS.DataAnalytics.Infrastructure.FeignClients;

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

            services.AddLogging(builder => { builder.AddConsole(); });

            //AppSettings Section Reference
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<IdentityAndAccountManagement.Application.Settings.AppSettings>(appSettingsSection);

            //JSON Web Token Authentication Configuration
            var appSettings = appSettingsSection.Get<IdentityAndAccountManagement.Application.Settings.AppSettings>();
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
                options.UseNpgsql(Configuration.GetConnectionString("PostgresSQLConnection"));
                //options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
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
            services.AddScoped<IArtworkRepository, ArtworkRepository>();
            services.AddScoped<IArtworkRecommendationRepository, ArtworkRecommendationRepository>();
            services.AddScoped<IArtworkReviewRepository, ArtworkReviewRepository>();
            services.AddScoped<IHobbyistFavoriteArtworkRepository, HobbyistFavoriteArtworkRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IArtEventCommandService, ArtEventService>();
            services.AddScoped<IArtEventQueryService, ArtEventQueryService>();
            services.AddScoped<IParticipantQueryService, ParticipantQueryService>();
            services.AddScoped<IParticipantCommandService, ParticipantCommandService>();

            services.AddScoped<IArtworkCommandService, ArtworkCommandService>();
            services.AddScoped<IArtworkRecommendationCommandService, ArtworkRecommendationCommandService>();
            services.AddScoped<IArtworkReviewCommandService, ArtworkReviewCommandService>();
            services.AddScoped<IHobbyistFavoriteArtworkCommandService, HobbyistFavoriteArtworkCommandService>();

            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityAndAccountManagementCommandService, IdentityAndAccountManagementCommandService>();
            services.AddScoped<IProfileCommandService, ProfileCommandService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IHobbyistRepository, HobbyistRepository>();
            services.AddScoped<IFollowerRepository, FollowerRepository>();

            services.AddScoped<IConductReportRepository, ConductReportRepository>();
            services.AddScoped<IConductReportService, ConductReportCommandService>();

            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationCommandService, NotificationCommandService>();

            services.AddScoped<IMLTrainingDataRepository, MLTrainingDataRepository>();
            services.AddScoped<IDataAnalyticsCommandService, DataAnalyticsCommandService>();
            services.AddTransient<DataAnalyticsFacade>();
            services.AddTransient<PeruStarsMLServiceFeignClient>();

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
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer Scheme"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddHttpClient();
            services.AddHostedService<DataAnalyticsJob>();
            
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