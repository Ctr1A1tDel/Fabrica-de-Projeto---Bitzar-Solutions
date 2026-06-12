namespace Api.Application.Dashboard.DTOs
{
    public class DataPointDTO
    {
        public string Label { get; set; } = string.Empty;
        public decimal Value { get; set; }

        public DataPointDTO() { }

        public DataPointDTO(string label, decimal value)
        {
            Label = label;
            Value = value;
        }
    }
}
