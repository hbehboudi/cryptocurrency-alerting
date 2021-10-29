using EndPoint.Site.Models.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebSite.Application.Interfaces.FacadPatterns;
using WebSite.Application.Services.Users.Commands.Login;
using WebSite.Application.Services.Users.Commands.Register;
using WebSite.Common.Dto;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserFacad userFacad;

        public AuthenticationController(IUserFacad userFacad) =>
            this.userFacad = userFacad;

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            var error = Validate(registerViewModel);

            if (!string.IsNullOrEmpty(error))
            {
                return Json(new ResultDto(false, error));
            }

            var registerRequest = new RegisterRequest(registerViewModel.FirstName, registerViewModel.LastName, registerViewModel.Email, registerViewModel.Password);
            var resultDto = userFacad.RegisterService.Execute(registerRequest);

            return Json(resultDto);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var error = Validate(loginViewModel);

            if (!string.IsNullOrEmpty(error))
            {
                return Json(new ResultDto(false, error));
            }

            var loginRequest = new LoginRequest(loginViewModel.Email, loginViewModel.Password, loginViewModel.IsPersistent);
            var loginResult = userFacad.LoginService.Execute(loginRequest);

            return Json(loginResult);
        }

        public string Validate(RegisterViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName) ||
                string.IsNullOrWhiteSpace(request.LastName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                return "لطفا تمامی موارد را ارسال نمایید.";
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return "شما قبلا ثبت نام کرده‌اید.";
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            if (!Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase).Success)
            {
                return "ایمیل خود را به درستی وارد نمایید.";
            }

            if (request.Password.Length < 8)
            {
                return "رمز عبور باید حداقل از ۸ کاراکتر تشکیل شده باشد.";
            }

            var passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])";

            if (!Regex.Match(request.Password, passwordRegex, RegexOptions.None).Success)
            {
                return "رمز عبور باید شامل حرف بزرگ، حرف کوچک، عدد و کاراکتر خاص باشد.";
            }

            if (request.Password != request.ConfirmPassword)
            {
                return "رمز عبور با تکرار آن برابر نیست";
            }

            return null;
        }

        public string Validate(LoginViewModel loginViewModel)
        {
            if (string.IsNullOrWhiteSpace(loginViewModel.Email) ||
                string.IsNullOrWhiteSpace(loginViewModel.Password))
            {
                return "لطفا تمامی موارد را ارسال نمایید.";
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            if (!Regex.Match(loginViewModel.Email, emailRegex, RegexOptions.IgnoreCase).Success)
            {
                return "ایمیل خود را به درستی وارد نمایید.";
            }

            if (loginViewModel.Password.Length < 8)
            {
                return "رمز عبور باید حداقل از ۸ کاراکتر تشکیل شده باشد.";
            }

            var passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            if (!Regex.Match(loginViewModel.Password, passwordRegex, RegexOptions.None).Success)
            {
                return "رمز عبور باید شامل حرف بزرگ، حرف کوچک، عدد و کاراکتر خاص باشد.";
            }

            return null;
        }
    }
}
