using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Models {
    public class TokensInfo {
        public string AccessToken { get; }
        public string RefreshToken { get; }

        public TokensInfo() { }

        public TokensInfo(string accessToken, string refreshToken) {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
