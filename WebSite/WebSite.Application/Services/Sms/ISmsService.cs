using System.Threading.Tasks;

namespace WebSite.Application.Services.Sms
{
    public interface ISmsService
    {
        Task Execute(string phoneNumber, string message);
    }
}
