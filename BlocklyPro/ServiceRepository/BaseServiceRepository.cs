using System;
using System.Security.Policy;
using BlocklyPro.Utility;

namespace BlocklyPro.ServiceRepository
{
    public class BaseServiceRepository
    {
        protected string BaseApiEndpoint { get; } = GlobalConfig.EndPoint;

        public BaseServiceRepository()
        {
        }
        public BaseServiceRepository(string version)
        {
            BaseApiEndpoint = BaseApiEndpoint.AsUrlCombineWith(version);
        }
    }
}
