using System.Threading.Tasks;
using BlocklyPro.Models;
using BlocklyPro.Utility;

namespace BlocklyPro.ServiceRepository.Identity
{
    public class IdentityServiceRepository: BaseServiceRepository,IIdentityServiceRepository
    {
        private readonly IXHRServiceRepository _serviceRepository;
        private readonly string loginEndpoint = "/identity/login";
        public readonly string registerEndPoint = "/identity/register";
       
        public IdentityServiceRepository(IXHRServiceRepository serviceRepository):base("/api/v1")
        {
            loginEndpoint = BaseApiEndpoint.AsUrlCombineWith(loginEndpoint);
            registerEndPoint = BaseApiEndpoint.AsUrlCombineWith(registerEndPoint);
            _serviceRepository = serviceRepository;
        }
        public async Task<TokenModel> Login(Request<LoginModel> request)
        {
            var token = await _serviceRepository.Post<TokenModel>(request.ToXhrRequest(loginEndpoint));
            return token;
        }

        public async Task<TokenModel> Register(Request<RegisterModel> request)
        {
            var token = await _serviceRepository.Post<TokenModel>(request.ToXhrRequest(registerEndPoint));
            return token;
        }
    }
}
