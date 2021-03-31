using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services.Auth {
    public class RefreshTokenFactory : IRefreshTokenFactory {

        private const int TOKEN_BYTES_LENGTH = 32;

        public string GenerateRefreshToken() {
            var randomNumber = new byte[TOKEN_BYTES_LENGTH];
            using var rng = RandomNumberGenerator.Create(); 
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
