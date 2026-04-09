using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuditoriaController : ControllerBase
{
    private readonly IAuditoriaService _auditoria;

    public AuditoriaController(IAuditoriaService auditoria)
    {
        _auditoria = auditoria;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var logs = _auditoria.Listar();
        return Ok(logs.OrderByDescending(l => l.Data));
    }
}