using Labest.Application.DTOs;
using Labest.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labest.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly MovimentacaoService _service;

        public MovimentacaoController(MovimentacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Movimentar([FromBody] MovimentacaoRequestDto dto)
        {
            await _service.Movimentar(dto.ProdutoId, dto.Tipo, dto.Quantidade);

            return Ok("Movimentação realizada com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movimentacoes = await _service.ObterTodos();
            return Ok(movimentacoes);
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> ObterPorProduto(Guid produtoId)
        {
            var movimentacoes = await _service.ObterPorProduto(produtoId);

            return Ok(movimentacoes);
        }
    }
}
