using Dominio.DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace IMDb_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _uservice;

        public UserController(IUserService userservice)
        {
            _uservice = userservice;
        }

        [AllowAnonymous]
        [HttpPost("Cadastrar")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Cadastrar(CreateUserDto createUser, CancellationToken cancellation)
        {
            var result = await _uservice.CreateUser(createUser,cancellation);
            if (result.Sucesso)
                return Ok();
            return BadRequest(result.Mensagem);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost("CriarAdm")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarAdm(CreateUserDto createUser, CancellationToken cancellation) 
        {
            var result = await _uservice.CreateAdm(createUser, cancellation);
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUserDto loginUser, CancellationToken cancellation)
        {
            var result = await _uservice.Login(loginUser, cancellation);
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpPut("AtualizarConta")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarConta(int id,CreateUserDto updateUser, CancellationToken cancellation)
        {
            var result = await _uservice.UpdateUser(id, updateUser, cancellation);
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpDelete("ExcluirUsuario")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExcluirUsuario(int id, string email, CancellationToken cancellation)
        {
            var result = await _uservice.DeleteUser(id, email, cancellation);
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpDelete("ExcluirAdm")]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExcluirAdm(int id, string email, CancellationToken cancellation)
        {
            var result = await _uservice.DeleteUser(id, email, cancellation);
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpGet("PegarTodosUsuarios")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public  IActionResult PegarTodos()
        {
            var result = _uservice.GetAllUsers();
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }
    }
}
