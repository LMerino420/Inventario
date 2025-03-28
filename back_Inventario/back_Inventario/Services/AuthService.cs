using back_Inventario.Models;
using back_Inventario.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace back_Inventario.Services
{
    public class AuthService(DbInventarioContext cntx, IConfiguration config) : IAuthService
    {
        //-------------------
        //Registrar usuario
        //-------------------
        public async Task<UserAccess?> RegistAsync(UserDto req)
        {
            //Verifica que el usuario no exista registrado
            if (await cntx.UserAccesses.AnyAsync(u => u.UsrName == req.UsrName))
            {
                return null;
            }

            var user = new UserAccess();
            var hashedPwd = new PasswordHasher<UserAccess>()
                .HashPassword(user, req.Password);

            user.UsrName = req.UsrName;
            user.UsrHash = hashedPwd;
            user.FrsName = req.FrsName;
            user.LstName = req.LstName;
            user.IdRol = 1;

            cntx.UserAccesses.Add(user);
            await cntx.SaveChangesAsync();

            return user;
        }

        //-------------------
        //LOGIN DEL SISTEMA
        //-------------------
        public async Task<TokenResponseDto?> LoginAsync(LoginDto req)
        {
            var user = await cntx.UserAccesses.FirstOrDefaultAsync(u => u.UsrName.Equals(req.Username));
            if (user == null)
            {
                return null;
            }
            if (new PasswordHasher<UserAccess>().VerifyHashedPassword(user, user.UsrHash, req.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }
            return await CreateTokenResponse(user);
        }

        //---------------------------
        //CREAR RESPUESTA DE TOKEN
        //---------------------------
        public async Task<TokenResponseDto> CreateTokenResponse(UserAccess? usr)
        {
            return new TokenResponseDto
            {
                AccessToken = CreateJWT(usr),
                RefreshToken = await CreateAndSaveRefreshToken(usr)
            };
        }

        //--------------
        //CREAR JWT
        //--------------
        private string CreateJWT(UserAccess usr)
        {
            //Variable para almacenar la informacion de JWT
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,usr.UsrName),
                new Claim(ClaimTypes.NameIdentifier,usr.IdUser.ToString()),
                new Claim(ClaimTypes.Role,usr.IdRol.ToString())
            };

            //Genera el codigo de encriptacion del token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            //Descripcion del JSON que contentra el token
            var tokenDescriptor = new JwtSecurityToken(
                issuer: config.GetValue<string>("AppSettings:Issuer"),
                audience: config.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddHours(4),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        //------------------------
        //GENERAR REFRESH-TOKEN
        //------------------------
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        //-------------------------------
        //CREAR Y GUARAR TOKEN-REFRESH
        //-------------------------------
        private async Task<string> CreateAndSaveRefreshToken(UserAccess usr)
        {
            var refreshToken = GenerateRefreshToken();
            usr.RefreshToken = refreshToken;
            usr.RefreshTokenExpireTime = DateTime.UtcNow.AddDays(7);
            await cntx.SaveChangesAsync();
            return refreshToken;
        }
    }
}
