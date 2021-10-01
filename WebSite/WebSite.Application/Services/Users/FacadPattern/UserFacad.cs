using Microsoft.AspNetCore.Identity;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Email;
using WebSite.Application.Services.Sms;
using WebSite.Application.Services.Users.Commands.EditProfile;
using WebSite.Application.Services.Users.Commands.ForgotPassword;
using WebSite.Application.Services.Users.Commands.Login;
using WebSite.Application.Services.Users.Commands.Logout;
using WebSite.Application.Services.Users.Commands.Register;
using WebSite.Application.Services.Users.Queries.GetProfile;
using WebSite.Domain.Entities.Users;

namespace WebSite.Application.Services.Users.FacadPattern
{
    public class UserFacad : IUserFacad
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly IEmailService emailService;

        private readonly ISmsService smsService;

        private readonly IDataBaseContext dataBaseContext;

        private IRegisterService registerService;

        private ILoginService loginService;

        private ILogoutService logoutService;

        private IForgotPasswordService forgotPasswordService;

        private IEditProfileService editProfileService;

        private IGetProfileService getProfileService;

        public UserFacad(UserManager<User> userManager, SignInManager<User> signInManager,
            IEmailService emailService, ISmsService smsService, IDataBaseContext dataBaseContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailService = emailService;
            this.smsService = smsService;
            this.dataBaseContext = dataBaseContext;
        }

        public IRegisterService RegisterService
        {
            get
            {
                return registerService ??= new RegisterService(userManager, signInManager);
            }
        }

        public ILoginService LoginService
        {
            get
            {
                return loginService ??= new LoginService(userManager, signInManager);
            }
        }

        public ILogoutService LogoutService
        {
            get
            {
                return logoutService ??= new LogoutService(signInManager);
            }
        }

        public IForgotPasswordService ForgotPasswordService
        {
            get
            {
                return forgotPasswordService ??= new ForgotPasswordService(userManager, emailService, smsService, dataBaseContext);
            }
        }

        public IEditProfileService EditProfileService
        {
            get
            {
                return editProfileService ??= new EditProfileService(userManager);
            }
        }

        public IGetProfileService GetProfileService
        {
            get
            {
                return getProfileService ??= new GetProfileService(userManager);
            }
        }
    }
}
