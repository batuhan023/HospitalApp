using HospitalApp.Shared;
using HospitalApp.Shared.Model;

namespace HospitalApp.Client.Services.ForAuth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin user);
        Task<bool> IsUserAuthenticated();
    }
}
