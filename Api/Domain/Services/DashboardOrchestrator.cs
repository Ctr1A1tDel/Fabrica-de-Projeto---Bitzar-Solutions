using Api.Domain.Ports;
using MiniExcelLibs;
using System.Text.Json;

public class DashboardOrchestrator
{
    private readonly IPythonService _pythonService;

    public DashboardOrchestrator(IPythonService pythonService)
    {
        _pythonService = pythonService;
    }

    public async Task<string> ProcessarFluxoExcel(IFormFile file, string prompt)
    {
        using var stream = file.OpenReadStream();
        var rows = stream.Query().ToList(); 
        var jsonDados = JsonSerializer.Serialize(new { data = rows });

        string tipo = prompt.Contains("pizza") ? "donut" : "bar";

        return await _pythonService.GerarConfigApexAsync(jsonDados, tipo);
    }
}