using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PERUSTARS.IdentityAndAccountManagement.Application.Settings;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;
using PERUSTARS.IdentityAndAccountManagement.Domain.Repositories;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly IRequestHandler<ValidateJwtTokenQuery, long?> _validateJwtTokenQueryHandler;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, IRequestHandler<ValidateJwtTokenQuery, long?> validateJwtTokenQueryHandler)
        {
            _next = next;
            _validateJwtTokenQueryHandler = validateJwtTokenQueryHandler;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var validateJwtTokenQuery = new ValidateJwtTokenQuery { Token = token };
            var userId = await _validateJwtTokenQueryHandler.Handle(validateJwtTokenQuery, new CancellationToken());
            if (userId != null)
            {
                context.Items["User"] = await userRepository.FindByIdAsync(userId.Value);
            }

            await _next(context);
        }
    }
}

