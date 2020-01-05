using AutoMapper;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.AppService
{
    public class BaseAppService
    {
        protected readonly IMapper _mapper;

        public BaseAppService(ICoreInjector coreInjector)
        {
            _mapper = coreInjector.Mapper;
        }
    }
}
