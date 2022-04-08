namespace WebSite.Application.Services.Users.Commands.EditProfile
{
    public class EditProfileRequest
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public string Name { get; }

        public EditProfileRequest(string email, string phoneNumber, string name)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Name = name;
        }
    }
}
