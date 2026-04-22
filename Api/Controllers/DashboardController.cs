using Api.Application.DTOs;
using Api.Domain.Ports;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IPythonService _pythonService;

    public DashboardController(IPythonService pythonService)
    {
        _pythonService = pythonService;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Gerar([FromForm] RequestDTO request)
        {
            if (request.File == null) return BadRequest("Arquivo não enviado.");
    
            var resultado = await _orchestrator.ProcessarFluxoExcel(request.File, request.Propt);
            return Ok(new { apexConfig = resultado });
        }
}