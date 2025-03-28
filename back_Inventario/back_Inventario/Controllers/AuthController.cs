using back_Inventario.Models;
using back_Inventario.Models.Dtos;
using back_Inventario.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authSrv) : ControllerBase
    {
        //Registro de usuario
        [HttpPost("regist")]
        public async Task<ActionResult<UserAccess>> Register(UserDto req)
        {
            var resp = new ResponseModel();

            var user = await authSrv.RegistAsync(req);
            if (user == null) {
                resp.Success = false;
                resp.Message = "Username already exist.!";
                return BadRequest(resp);
            }
            
            resp.Success = true;
            resp.Object = user;
            
            return Ok(resp);
        }

        //Login
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>>Login(LoginDto req)
        {
            var resp = new ResponseModel();
            var result = await authSrv.LoginAsync(req);

            if (result is null)
            {
                resp.Success = false;
                resp.Message = "Invalid username or password.!";
                return BadRequest(resp);
            }
            resp.Success = true;
            resp.Object = result;
            return Ok(resp);
        }

        //Endpoint de autenticacion
        [Authorize]
        [HttpGet("auth-only")]
        public IActionResult AuthOnlyEndpoint()
        {
            return Ok("You are authenticated!!");
        }
    }
}
