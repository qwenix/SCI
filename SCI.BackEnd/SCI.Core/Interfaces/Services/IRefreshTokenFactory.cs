using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IRefreshTokenFactory {
        string GenerateRefreshToken();
    }
}
