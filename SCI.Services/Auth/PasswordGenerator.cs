using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services.Auth {
    public class PasswordGenerator : IPasswordGenerator {

        private const int PASSWORD_LENGTH = 10;
        private const int NON_ALPHANUMERIC_COUNT = 2;

        private static readonly char[] Punctuations = "!@#$%^&*()_-+=[{]};:>|./?".ToCharArray();

        public string GeneratePassword() {
            if (PASSWORD_LENGTH < 1 || PASSWORD_LENGTH > 128) {
                throw new ArgumentException(nameof(PASSWORD_LENGTH));
            }

            if (NON_ALPHANUMERIC_COUNT > PASSWORD_LENGTH || NON_ALPHANUMERIC_COUNT < 0) {
                throw new ArgumentException(nameof(NON_ALPHANUMERIC_COUNT));
            }

            using var rng = RandomNumberGenerator.Create(); 
            var byteBuffer = new byte[PASSWORD_LENGTH];

            rng.GetBytes(byteBuffer);

            var count = 0;
            var characterBuffer = new char[PASSWORD_LENGTH];

            for (var iter = 0; iter < PASSWORD_LENGTH; iter++) {
                var i = byteBuffer[iter] % 87;

                if (i < 10) {
                    characterBuffer[iter] = (char)('0' + i);
                }
                else if (i < 36) {
                    characterBuffer[iter] = (char)('A' + i - 10);
                }
                else if (i < 62) {
                    characterBuffer[iter] = (char)('a' + i - 36);
                }
                else {
                    characterBuffer[iter] = Punctuations[i - 62];
                    count++;
                }
            }

            if (count >= NON_ALPHANUMERIC_COUNT) {
                return new string(characterBuffer);
            }

            int j;
            var rand = new Random();

            for (j = 0; j < NON_ALPHANUMERIC_COUNT - count; j++) {
                int k;
                do {
                    k = rand.Next(0, PASSWORD_LENGTH);
                }
                while (!char.IsLetterOrDigit(characterBuffer[k]));

                characterBuffer[k] = Punctuations[rand.Next(0, Punctuations.Length)];
            }

            return new string(characterBuffer);
        }
    }
}
