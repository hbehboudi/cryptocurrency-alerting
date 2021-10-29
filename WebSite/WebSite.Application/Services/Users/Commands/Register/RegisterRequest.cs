namespace WebSite.Application.Services.Users.Commands.Register
{
    public class RegisterRequest
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }

        public RegisterRequest(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
