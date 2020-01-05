using System;
using System.Threading.Tasks;
using BlocklyPro.Api.Configurations;
using BlocklyPro.Api.Model.Identity;
using BlocklyPro.Core.AppService.Dto.UserDto;
using BlocklyPro.Core.AppService.Interfaces;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Utility;
using Microsoft.AspNetCore.Mvc; 

namespace BlocklyPro.Api.Controllers.V1
{
    [Route(Version + "identity")]
    public class IdentityController : V1BaseController
    {
        private readonly IIdentityAppService _identityAppService;

        public IdentityController(IIdentityAppService identityAppService,ICoreInjector coreInjector):base(coreInjector)
        {
            _identityAppService = identityAppService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel item)
        {
            try
            {
                var result = await _identityAppService.Login(_mapper.Map<LoginDto>(item));
                return Ok(new TokenModel {Token = Jwt.TokenGenerator(result)});
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel item)
        {
            try
            {
                var result = await _identityAppService.Register(_mapper.Map<RegisterDto>(item));
                return Ok(new TokenModel { Token = Jwt.TokenGenerator(result) });
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
