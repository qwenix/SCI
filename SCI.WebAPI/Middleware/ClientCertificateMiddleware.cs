using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SCI.Core.Interfaces.Services;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Middleware {
    public class ClientCertificateMiddleware {
        private readonly RequestDelegate next;
        private readonly CertificateInfo info;

        public ClientCertificateMiddleware(RequestDelegate next,
            IOptions<CertificateInfo> options) {
            this.next = next;
            info = options.Value;
        }

        public async Task Invoke(HttpContext context) {
            await next.Invoke(context);
        }
    }
}
