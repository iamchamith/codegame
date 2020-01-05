using System;
using System.Threading.Tasks;
using BlocklyPro.Core.AppService.Dto;
using BlocklyPro.Core.AppService.Dto.UserDto;
using BlocklyPro.Core.AppService.Interfaces;
using BlocklyPro.Core.Domain;
using BlocklyPro.Core.Infrastructure;
using BlocklyPro.Core.Utility;
using Microsoft.EntityFrameworkCore;

namespace BlocklyPro.Core.AppService
{
    public class IdentityAppService : BaseAppService, IIdentityAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IdentityAppService(IUnitOfWork unitOfWork, ICoreInjector coreInjector) : base(coreInjector)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Register(RegisterDto request)
        {
            try
            {
                var user = new User(request.Name, request.Email, request.Password);
                var obj = await _unitOfWork.UserRepository.CreateAndSave(user);
                return _mapper.Map<UserDto>(obj);
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }

        public async Task<UserDto> Login(LoginDto request)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.TableAsNoTracking.FirstOrDefaultAsync(p => p.Email == request.Email);
                if (user.IsNull())
                {
                    throw new InvalidDataException("Username not found");
                }
                user.Validate(request.Password);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                throw e.HandleException();
            }
        }
    }
}
