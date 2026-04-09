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
        private readonly IAuditoriaService _auditoria;
        private readonly ILogger<MovimentacaoController> _logger;

        public MovimentacaoController(MovimentacaoService service, IAuditoriaService auditoria, ILogger<MovimentacaoController> logger)
        {
            _service = service;
            _auditoria = auditoria;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Movimentar([FromBody] MovimentacaoRequestDto dto)
        {
            await _service.Movimentar(dto.ProdutoId, dto.Tipo, dto.Quantidade);

            _auditoria.Registrar(User.Identity?.Name ?? "Sistema",
                                   "Id do Produto movimentado no estoque", dto.ProdutoId.ToString());

            _logger.LogInformation("Id do Produto movimentado:", dto.ProdutoId);

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
