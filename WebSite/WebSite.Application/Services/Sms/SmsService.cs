using Kavenegar;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace WebSite.Application.Services.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration configuration;

        public SmsService(IConfiguration configuration) =>
            this.configuration = configuration;

        public Task Execute(string phoneNumber, string message)
        {
            var sender = configuration["Sms:SenderNumber"];
            var api = CreateKavenegarApi();

            api.Send(sender, phoneNumber, message);

            return Task.CompletedTask;
        }

        private KavenegarApi CreateKavenegarApi()
        {
            var apikey = configuration["Sms:Apikey"];
            return new KavenegarApi(apikey);
        }
    }
}
