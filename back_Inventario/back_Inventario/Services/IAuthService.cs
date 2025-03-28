using back_Inventario.Models;
using back_Inventario.Models.Dtos;

namespace back_Inventario.Services
{
    public interface IAuthService
    {
        Task<UserAccess?> RegistAsync(UserDto req);
        Task<TokenResponseDto> LoginAsync(LoginDto req);
    }
}
