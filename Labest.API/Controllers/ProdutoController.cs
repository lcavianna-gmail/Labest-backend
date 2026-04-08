using Labest.Application.DTOs;
using Labest.Application.Services;
using Labest.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Labest.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ObterTodos());

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoCreateDto dto) => Ok(await _service.Adicionar(dto));

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
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _service.Remover(id);
            return NoContent();
        }
    }
}
