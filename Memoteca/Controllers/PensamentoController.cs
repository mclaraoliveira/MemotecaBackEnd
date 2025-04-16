using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Memoteca.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Memoteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensamentoController : ControllerBase
    {
        private readonly IPensamentoService _service;
        private readonly IMapper _mapper;

        public PensamentoController(IPensamentoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarPensamento([FromBody] PensamentoDto dto)
        {
            var sucesso = await _service.CriarPensamentoAsync(dto);
            if (sucesso)
                return Created("", "Pensamento criado com sucesso!");
            return BadRequest("Erro ao criar pensamento.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPensamento(int id, [FromBody] PensamentoDto dto)
        {
            var sucesso = await _service.AtualizarPensamentoAsync(id, dto);
            if (sucesso)
                return Ok("Pensamento atualizado com sucesso!");
            return NotFound("Pensamento não encontrado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirPensamento(int id)
        {
            var sucesso = await _service.ExcluirPensamentoAsync(id);
            if (sucesso)
                return Ok("Pensamento excluído com sucesso!");
            return NotFound("Pensamento não encontrado.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PensamentoModel>> BuscarPorId(int id)
        {
            var pensamento = await _service.BuscarPensamentoPorIdAsync(id);
            if (pensamento == null)
                return NotFound("Pensamento não encontrado.");
            return Ok(pensamento);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<PensamentoModel>>> BuscarTodos()
        {
            var pensamentos = await _service.BuscarTodosPensamentosAsync();
            return Ok(pensamentos);
        }

        [HttpGet("{pagina}/{quantidade}")]
        public async Task<ActionResult<RetornoPaginado<PensamentoModel>>> BuscarPaginado(
            [FromQuery] int pagina = 1,
            [FromQuery] int quantidade = 10)
        {
            var retorno = await _service.BuscarPensamentosPaginadosAsync(pagina, quantidade);
            return Ok(retorno);
        }
    }
}
