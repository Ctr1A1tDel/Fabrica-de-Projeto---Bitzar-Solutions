using Api.Domain.Dashboard.ValueObjects;

namespace Api.Domain.Dashboard.Entities
{
    public class Dashboard
    {
        public DashboardId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Chart> Charts { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        private Dashboard(DashboardId id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Charts = new List<Chart>();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public static Dashboard Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do dashboard é obrigatório", nameof(name));

            return new Dashboard(DashboardId.New(), name, description ?? string.Empty);
        }

        public void AddChart(Chart chart)
        {
            if (chart == null)
                throw new ArgumentNullException(nameof(chart));

            if (Charts.Any(c => c.Id.Equals(chart.Id)))
                throw new InvalidOperationException("Gráfico já existe no dashboard");

            Charts.Add(chart);
            UpdateTimestamp();
        }

        public void RemoveChart(ChartId chartId)
        {
            var chart = Charts.FirstOrDefault(c => c.Id.Equals(chartId));
            if (chart != null)
            {
                Charts.Remove(chart);
                UpdateTimestamp();
            }
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Novo nome não pode estar vazio", nameof(newName));

            Name = newName;
            UpdateTimestamp();
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription ?? string.Empty;
            UpdateTimestamp();
        }

        public void Activate()
        {
            IsActive = true;
            UpdateTimestamp();
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdateTimestamp();
        }

        private void UpdateTimestamp() => UpdatedAt = DateTime.UtcNow;

        public int GetChartCount() => Charts.Count;
    }
}
