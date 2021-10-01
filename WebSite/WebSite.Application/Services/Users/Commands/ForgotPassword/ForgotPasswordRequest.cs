namespace WebSite.Application.Services.Users.Commands.ForgotPassword
{
    public class ForgotPasswordRequest
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public bool SendByEmail { get; }

        public ForgotPasswordRequest(string email, string phoneNumber, bool sendByEmail)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            SendByEmail = sendByEmail;
        }
    }
}
