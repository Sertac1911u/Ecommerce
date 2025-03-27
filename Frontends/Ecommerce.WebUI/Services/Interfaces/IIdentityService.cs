using Ecommerce.DtoLayer.IdentityDtos;

namespace Ecommerce.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
