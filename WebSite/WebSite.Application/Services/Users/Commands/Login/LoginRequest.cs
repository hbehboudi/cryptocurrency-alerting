namespace WebSite.Application.Services.Users.Commands.Login
{
    public class LoginRequest
    {
        public string Email { get; }

        public string Password { get; }

        public bool IsPersistent { get; }

        public LoginRequest(string email, string password, bool isPersistent)
        {
            Email = email;
            Password = password;
            IsPersistent = isPersistent;
        }
    }
}
