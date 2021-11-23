using WebSite.Common.Dto;

namespace WebSite.Application.Services.Users.Queries.GetProfile
{
    public interface IGetProfileService
    {
        public ResultDto<GetProfileDto> Execute(GetProfileRequest request);
    }
}
