using BlocklyPro.Core.Utility;

namespace BlocklyPro.Api.Controllers.V1
{
    public class V1BaseController: BaseController
    {
        protected const string Version = "api/v1/";
        public V1BaseController(ICoreInjector coreInjector):base(coreInjector)
        {
        }
    }
}
