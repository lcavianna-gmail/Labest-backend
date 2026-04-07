using Labest.Application.DTOs;
using Labest.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labest.API.Controllers
{
    //[Authorize]
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

    }
}
