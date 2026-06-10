namespace Api.Application.Dashboard.DTOs
{
    public class ChartDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public List<DataPointDTO> DataPoints { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}
