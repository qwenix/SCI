using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using SCI.Core.Interfaces.Services;
using SCI.WebAPI.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Configuration {
    public static class MiddlewareExtensions {

        public static IApplicationBuilder UseClientCertMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ClientCertificateMiddleware>();
        }
        public static IApplicationBuilder UseClientCertMiddleware(this IApplicationBuilder builder,
            IOptions<CertificateInfo> options) {
            return builder.UseMiddleware<ClientCertificateMiddleware>(options);
        }
    }
}
