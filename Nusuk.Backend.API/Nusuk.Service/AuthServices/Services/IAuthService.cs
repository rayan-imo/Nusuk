
using Nusuk.Services.AuthServices.Helper;

namespace Nusuk.Services.AuthServices.Services
{
    public interface IAuthService
    {
        public Task<AuthModel> RegisterAsync(RegisterModel model);
        public Task<AuthModel> LogInAsync(LogInModel model);

    }
}
