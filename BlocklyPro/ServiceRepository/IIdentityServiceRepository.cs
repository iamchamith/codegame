using System.Threading.Tasks;
using BlocklyPro.Models;
using BlocklyPro.Utility;

namespace BlocklyPro.ServiceRepository
{
    public interface IIdentityServiceRepository
    {
        Task<TokenModel> Login(Request<LoginModel> request);
        Task<TokenModel> Register(Request<RegisterModel> request);
    }
}
