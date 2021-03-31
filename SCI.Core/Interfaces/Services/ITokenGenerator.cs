using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface ITokenGenerator {
        string GenerateTokenForClaims(IEnumerable<Claim> userClaims);
    }
}
