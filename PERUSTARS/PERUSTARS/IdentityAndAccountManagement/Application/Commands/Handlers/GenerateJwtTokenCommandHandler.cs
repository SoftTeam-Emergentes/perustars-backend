using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PERUSTARS.IdentityAndAccountManagement.Application.Settings;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Commands;
using PERUSTARS.IdentityAndAccountManagement.Domain.Model.Events;

namespace PERUSTARS.IdentityAndAccountManagement.Application.Commands.Handlers
{
    public class GenerateJwtTokenCommandHandler : IRequestHandler<GenerateJwtTokenCommand, string>
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IPublisher _publisher;

        public GenerateJwtTokenCommandHandler(IOptions<AppSettings> appSettings, IPublisher publisher)
        {
            _appSettings = appSettings;
            _publisher = publisher;
        }

        public async Task<string> Handle(GenerateJwtTokenCommand request, CancellationToken cancellationToken)
        {
            var secret = _appSettings.Value.Secret;
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Sid, request.User.UserId.ToString()),
                new Claim(ClaimTypes.Name, request.User.Email)
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);

            GeneratedJwtTokenEvent generatedJwtTokenEvent = new GeneratedJwtTokenEvent
            {
                Token = tokenStr
            };
            await _publisher.Publish(generatedJwtTokenEvent);
            return tokenStr;
        }
    }
}

