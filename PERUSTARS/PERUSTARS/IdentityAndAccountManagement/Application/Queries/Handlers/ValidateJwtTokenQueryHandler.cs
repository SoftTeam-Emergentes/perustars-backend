using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PERUSTARS.IdentityAndAccountManagement.Application.Settings;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Queries;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Queries.Handlers
{
    public class ValidateJwtTokenQueryHandler : IRequestHandler<ValidateJwtTokenQuery, long?>
    {
        private readonly IOptions<AppSettings> _appSettings;

        public ValidateJwtTokenQueryHandler(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<long?> Handle(ValidateJwtTokenQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);

            try
            {
                tokenHandler.ValidateToken(request.Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = long.Parse(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);

                return userId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}

