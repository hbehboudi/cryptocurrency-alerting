namespace WebSite.Application.Services.Users.Queries.GetProfile
{
    public class GetProfileDto
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public string Name { get; }

        public bool IsPublisher { get; }

        public bool IsPremium { get; }

        public GetProfileDto(string email, string phoneNumber, string name, bool isPublisher, bool isPremium)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Name = name;
            IsPublisher = isPublisher;
            IsPremium = isPremium;
        }
    }
}
