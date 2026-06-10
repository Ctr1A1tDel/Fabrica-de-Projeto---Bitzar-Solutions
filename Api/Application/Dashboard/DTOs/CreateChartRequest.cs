namespace Api.Application.Dashboard.DTOs
{
    public class CreateChartRequest
    {
        public Guid DashboardId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<DataPointDTO> DataPoints { get; set; } = new();
    }
}
