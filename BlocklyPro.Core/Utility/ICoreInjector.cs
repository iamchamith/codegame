using AutoMapper;

namespace BlocklyPro.Core.Utility
{
    public interface ICoreInjector
    {
        IMapper Mapper { get; set; }
    }
    public class CoreInjector: ICoreInjector
    {
        public IMapper Mapper { get; set; }

        public CoreInjector(IMapper mapper)
        {
            Mapper = mapper;
        }
     }
}
