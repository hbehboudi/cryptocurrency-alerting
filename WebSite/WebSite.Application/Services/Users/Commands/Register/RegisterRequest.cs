namespace WebSite.Application.Services.Users.Commands.Register
{
    public class RegisterRequest
    {
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }

        public bool IsPublisher { get; set; }

        public RegisterRequest(string firstName, string lastName, string email, string password, bool isPublisher)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsPublisher = isPublisher;
        }
    }
}
