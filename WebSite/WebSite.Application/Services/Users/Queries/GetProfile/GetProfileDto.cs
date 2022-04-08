namespace WebSite.Application.Services.Users.Queries.GetProfile
{
    public class GetProfileDto
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public string Name { get; }

        public GetProfileDto(string email, string phoneNumber, string name)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Name = name;
        }
    }
}
