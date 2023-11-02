using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PERUSTARS.CommunicationAndNotificationManagement.Application.Commands.Services;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Repositories;
using PERUSTARS.CommunicationAndNotificationManagement.Domain.Services;
using PERUSTARS.CommunicationAndNotificationManagement.Infraestructure.Repositories;
using PERUSTARS.Shared.Domain.Repositories;
using PERUSTARS.Shared.Infrastructure.Configuration;
using PERUSTARS.Shared.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Text;

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

 
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<INotificationCommandService, NotificationCommandService>();


            // Apply Endpoints Naming Convention
            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper Setup
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PERUSTARS", Version = "v1" });
                c.EnableAnnotations();
            });

            

            services.Configure<ExceptionHandlerOptions>(options => {
                options.ExceptionHandler = default;
                options.ExceptionHandlingPath = PathString.FromUriComponent("/error");
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
