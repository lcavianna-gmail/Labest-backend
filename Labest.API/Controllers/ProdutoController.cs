using Labest.Application.DTOs;
using Labest.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labest.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        private readonly IAuditoriaService _auditoria;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ProdutoService service, IAuditoriaService auditoria, ILogger<ProdutoController> logger)
        {
            _service = service;
            _auditoria = auditoria;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ObterTodos());

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoCreateDto dto)
        {
            var result = await _service.Adicionar(dto);

            _auditoria.Registrar(User.Identity?.Name ?? "Sistema",
                                    "Criou Produto", dto.Nome);

            _logger.LogInformation("Produto criado: {Nome}", dto.Nome);

            return Ok(result);
        }


        [HttpGet("{id}/saldo")]
        public async Task<IActionResult> ObterSaldo(Guid id)
        {
            var saldo = await _service.ObterSaldo(id);
            return Ok(saldo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoUpdateDto dto)
        {
            await _service.Atualizar(id, dto);

            _auditoria.Registrar(User.Identity?.Name ?? "Sistema",
                                  "Atualizou o Produto", dto.Nome);

            _logger.LogInformation("Produto atualizado: {Nome}", dto.Nome);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _service.Remover(id);

            _auditoria.Registrar(User.Identity?.Name ?? "Sistema",
                                  "Removido Produto id:", id.ToString());

            _logger.LogInformation("Produto removido: {Nome}", id.ToString());

            return NoContent();
        }
    }
}
