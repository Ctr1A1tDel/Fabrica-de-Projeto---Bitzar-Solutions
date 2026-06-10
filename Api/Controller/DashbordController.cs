using Api.Application.Dashboard;
using Api.Application.Dashboard.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardApplicationService _applicationService;

        public DashboardController(DashboardApplicationService applicationService)
        {
            _applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DashboardDTO>> CreateDashboard([FromBody] CreateDashboardRequest request)
        {
            try
            {
                var dashboard = await _applicationService.CreateDashboardAsync(request);
                return CreatedAtAction(nameof(GetDashboardById), new { id = dashboard.Id }, dashboard);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DashboardDTO>> GetDashboardById(Guid id)
        {
            var dashboard = await _applicationService.GetDashboardByIdAsync(id);
            if (dashboard == null)
                return NotFound(new { message = $"Dashboard com ID {id} não encontrado" });

            return Ok(dashboard);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DashboardDTO>>> GetAllDashboards()
        {
            var dashboards = await _applicationService.GetAllDashboardsAsync();
            return Ok(dashboards);
        }

        [HttpPost("{dashboardId}/charts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DashboardDTO>> AddChartToDashboard(Guid dashboardId, [FromBody] CreateChartRequest request)
        {
            try
            {
                request.DashboardId = dashboardId;
                var dashboard = await _applicationService.AddChartToDashboardAsync(request);
                return Ok(dashboard);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{dashboardId}/charts/{chartId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DashboardDTO>> RemoveChartFromDashboard(Guid dashboardId, Guid chartId)
        {
            try
            {
                var dashboard = await _applicationService.RemoveChartFromDashboardAsync(dashboardId, chartId);
                return Ok(dashboard);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{dashboardId}/name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DashboardDTO>> UpdateDashboardName(Guid dashboardId, [FromBody] UpdateNameRequest request)
        {
            try
            {
                var dashboard = await _applicationService.UpdateDashboardNameAsync(dashboardId, request.NewName);
                return Ok(dashboard);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteDashboard(Guid id)
        {
            await _applicationService.DeleteDashboardAsync(id);
            return NoContent();
        }
    }

    public class UpdateNameRequest
    {
        public string NewName { get; set; } = string.Empty;
    }
}