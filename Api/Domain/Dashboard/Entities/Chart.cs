using Api.Domain.Dashboard.ValueObjects;

namespace Api.Domain.Dashboard.Entities
{
    public class Chart
    {
        public ChartId Id { get; private set; }
        public string Title { get; private set; }
        public string Type { get; private set; } // "bar", "line", "pie", etc.
        public List<DataPoint> DataPoints { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Chart(ChartId id, string title, string type, List<DataPoint> dataPoints)
        {
            Id = id;
            Title = title;
            Type = type;
            DataPoints = dataPoints ?? new List<DataPoint>();
            CreatedAt = DateTime.UtcNow;
        }

        public static Chart Create(string title, string type, List<DataPoint> dataPoints)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título do gráfico é obrigatório", nameof(title));

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Tipo do gráfico é obrigatório", nameof(type));

            if (dataPoints == null || dataPoints.Count == 0)
                throw new ArgumentException("Gráfico deve ter pelo menos um ponto de dados", nameof(dataPoints));

            return new Chart(ChartId.New(), title, type, dataPoints);
        }

        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Novo título não pode estar vazio", nameof(newTitle));

            Title = newTitle;
        }

        public void AddDataPoint(DataPoint dataPoint)
        {
            if (dataPoint == null)
                throw new ArgumentNullException(nameof(dataPoint));

            DataPoints.Add(dataPoint);
        }

        public void ClearDataPoints() => DataPoints.Clear();
    }
}
