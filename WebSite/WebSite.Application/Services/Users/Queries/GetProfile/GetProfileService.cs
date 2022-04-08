using Microsoft.AspNetCore.Identity;
using WebSite.Common.Dto;
using WebSite.Domain.Entities.Users;

namespace WebSite.Application.Services.Users.Queries.GetProfile
{
    public class GetProfileService : IGetProfileService
    {
        private readonly UserManager<User> userManager;

        public GetProfileService(UserManager<User> userManager) =>
            this.userManager = userManager;

        public ResultDto<GetProfileDto> Execute(GetProfileRequest request)
        {
            var user = userManager.FindByNameAsync(request.Email).Result;

            var result = new GetProfileDto(user.Email, user.PhoneNumber, user.Name);

            return new ResultDto<GetProfileDto>(true, "Profile returned successfully.", result);
        }
    }
}
