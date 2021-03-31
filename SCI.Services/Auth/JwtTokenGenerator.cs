using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services.Auth {
    public class JwtTokenGenerator : ITokenGenerator {

        private readonly int tokenLifetime;

        public TokenValidationParameters TokenValidationParameters { get; }

        public JwtTokenGenerator(IConfiguration configuration) {
            var settings = GetAuthTokenSettings(configuration);
            TokenValidationParameters = new TokenValidationParameters {
                ValidateLifetime = settings.ValidateLifetime,
                ValidateIssuer = true,
                ValidIssuer = settings.ValidIssuer,
                ValidateAudience = true,
                ValidAudience = settings.ValidAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(settings.SigningKey)),
                ClockSkew = TimeSpan.Zero
            };
            tokenLifetime = settings.TokenLifetime;
        }

        public string GenerateTokenForClaims(IEnumerable<Claim> userClaims) {
            DateTime currentDate = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: TokenValidationParameters.ValidIssuer,
                    audience: TokenValidationParameters.ValidAudience,
                    notBefore: currentDate,
                    claims: userClaims,
                    expires: currentDate.Add(TimeSpan.FromMinutes(tokenLifetime)),
                    signingCredentials: new SigningCredentials(
                        key: TokenValidationParameters.IssuerSigningKey,
                        algorithm: SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler()
                .WriteToken(jwt);
        }

        private static TokenSettings GetAuthTokenSettings(IConfiguration configuration) {
            var tokenSettings = new TokenSettings();
            configuration.Bind("AuthToken", tokenSettings);
            return tokenSettings;
        }

        private class TokenSettings {
            public string ValidIssuer { get; set; }
            public string ValidAudience { get; set; }
            public string SigningKey { get; set; }
            public bool ValidateLifetime { get; set; }
            public int TokenLifetime { get; set; }
        } 
    }
}
