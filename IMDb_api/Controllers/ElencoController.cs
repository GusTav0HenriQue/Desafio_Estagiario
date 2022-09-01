using Dominio.DTOs.ElencoDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace IMDb_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ElencoController : ControllerBase
    {
        private readonly IElencoService _eService;

        public ElencoController(IElencoService eService)
        {
            _eService = eService;
        }
        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarElenco(CadastrarElencoDto cadastro, CancellationToken cancellation)
        {
            var result = await _eService.CadastrarElenco(cadastro, cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarElenco(int id, UpdateElencoDto updateElenco, CancellationToken cancellation)
        {
            var result = await _eService.UpdateElenco(id, updateElenco, cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpDelete("Deletar")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarElenco(int id, CancellationToken cancellation)
        {
            var result = await _eService.Delete(id, cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpGet("PegarTodos")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public  IActionResult PegarTodos()
        {
            var result = _eService.GetAllElenco();
            if (result.Sucesso)
                return Ok();
            return BadRequest(result.Mensagem);
        }
    }
}
