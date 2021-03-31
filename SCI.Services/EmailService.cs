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
            MailAddress from = new(DOMAIN_EMAIL, "SCI Admin");
            MailAddress to = new(email);
            MailMessage m = new(from, to);
            m.Subject = "Password";
            m.Body = $"<h2>Your password</h2><p>{message}</p";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new NetworkCredential("kdeniis2088@gmail.com", "ujlpts5E2088");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
