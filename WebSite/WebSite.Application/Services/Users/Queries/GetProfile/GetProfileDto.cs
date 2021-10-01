namespace WebSite.Application.Services.Users.Queries.GetProfile
{
    public class GetProfileDto
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public bool IsPublisher { get; }

        public bool IsPremium { get; }

        public GetProfileDto(string email, string phoneNumber, string firstName, string lastName, bool isPublisher, bool isPremium)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            IsPublisher = isPublisher;
            IsPremium = isPremium;
        }
    }
}
