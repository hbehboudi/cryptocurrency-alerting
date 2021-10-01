using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Application.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration) =>
            this.configuration = configuration;

        public Task Execute(string email, string subject, string body)
        {
            var client = CreateSmtpClient();
            var message = CreateMailMessage(email, subject, body);

            client.Send(message);

            return Task.CompletedTask;
        }

        private MailMessage CreateMailMessage(string userEmail, string subject, string body)
        {
            var from = configuration["Email:Username"];

            return new(from, userEmail, subject, body)
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            };
        }

        private SmtpClient CreateSmtpClient()
        {
            var port = int.Parse(configuration["Email:Port"]);
            var host = configuration["Email:Host"];
            var timeout = int.Parse(configuration["Email:Timeout"]);
            var username = configuration["Email:Username"];
            var password = configuration["Email:Password"];

            return new()
            {
                Port = port,
                Host = host,
                EnableSsl = true,
                Timeout = timeout,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(username, password)
            };
        }
    }
}
