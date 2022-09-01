using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AutoMapper;
using Dominio.DTOs.FilmesDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace IMDb_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class FilmeController  : ControllerBase
    {
        private readonly IFilmeService _fService;
        private readonly IMapper _mapper;
        public FilmeController(IFilmeService fService, IMapper mapper)
        {
            _fService = fService;
            _mapper = mapper;
        }

        [HttpPost("Cadastrar")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarFilme(CreateFilmeDto cadastro, CancellationToken cancellation)
        {
            var result = await _fService.CadastraFilme(cadastro, cancellation);
            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpPut("Atualizar")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFilme(int id, UpdateFilmeDto updateFilme, CancellationToken cancellation)
        {
            var result = await _fService.UpdateFilme(id, updateFilme, cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpDelete("Deletar")]
        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarFilme(int id, CancellationToken cancellation)
        {
            var result = await _fService.DeleteFilme(id, cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpPost("RegistrarAvaliacao")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarAvaliacao(RegistraAvaliaçaoFilmeDto avaliacao, CancellationToken cancellation) 
        {
            var result = await _fService.RegistrarAvaliacao(avaliacao, cancellation);

            if (result.Sucesso)
                return Ok();
            return BadRequest(result.Mensagem);
        }

        [HttpGet("PegarTodos")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public  IActionResult PegarTodos(CancellationToken cancellation)
        {
            var result = _fService.GetAllFilmes(cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpGet("PegarFilmeDetalhado")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetFilmeDetail(int id , CancellationToken cancellation)
        {
            var result = await _fService.GetFilmesDetail(id, cancellation);

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }

        [HttpGet("PegarFilmeComFiltro")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult GetFilmeByFiltros([FromQuery] ObterTodosFilmesDto obterTodosFilmesDto)
        {
            var result = _fService.GetFilmeByFiltros(obterTodosFilmesDto);

            if (result.Sucesso)
                return Ok(_mapper.Map<IEnumerable<FilmeDto>>(result.Value.ToList()));
            return BadRequest(result.Mensagem);

        }

        [HttpGet("PegarFilmeOrdenadoPorAvaliaçao")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetFilmeByAvaliacao()
        {
            var result = _fService.GetFilmeByAvaliacao();

            if (result.Sucesso)
                return Ok(result);
            return BadRequest(result.Mensagem);
        }
    }
}
