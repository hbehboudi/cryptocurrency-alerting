namespace WebSite.Application.Services.Users.Commands.Register
{
    public class RegisterRequest
    {
        public string Name { get; }

        public string Email { get; }

        public string Password { get; }

        public RegisterRequest(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
