using System.Threading.Tasks;
using BlocklyPro.Core.AppService.Dto;
using BlocklyPro.Core.AppService.Dto.UserDto;

namespace BlocklyPro.Core.AppService.Interfaces
{
    public interface IIdentityAppService
    {
        Task<UserDto> Register(RegisterDto request);
        Task<UserDto> Login(LoginDto request);
    }
}
