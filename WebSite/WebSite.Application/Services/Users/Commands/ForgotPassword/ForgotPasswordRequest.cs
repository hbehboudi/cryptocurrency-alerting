namespace WebSite.Application.Services.Users.Commands.ForgotPassword
{
    public class ForgotPasswordRequest
    {
        public string Email { get; }

        public ForgotPasswordRequest(string email) =>
            Email = email;
    }
}
