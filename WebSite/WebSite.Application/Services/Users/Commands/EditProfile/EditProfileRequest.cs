namespace WebSite.Application.Services.Users.Commands.EditProfile
{
    public class EditProfileRequest
    {
        public string Email { get; }

        public string PhoneNumber { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public EditProfileRequest(string email, string phoneNumber, string firstName, string lastName)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
