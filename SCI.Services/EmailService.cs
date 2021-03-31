using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    public class EmailService : IEmailService {

        private const string DOMAIN_EMAIL = "kdeniis2088@gmail.com";

        public async Task SendEmailAsync(string email, string message) {
            var smtpClient = new SmtpClient("smtp.gmail.com") {
                Port = 587,
                Credentials = new NetworkCredential(DOMAIN_EMAIL, "ujlpts5E2088"),
                EnableSsl = true,
            };

            await smtpClient.SendMailAsync(DOMAIN_EMAIL, email, "Password", message);
        }
    }
}
