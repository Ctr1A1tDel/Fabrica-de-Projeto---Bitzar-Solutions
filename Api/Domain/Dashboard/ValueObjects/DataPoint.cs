namespace Api.Domain.Dashboard.ValueObjects
{
    public class DataPoint
    {
        public string Label { get; private set; }
        public decimal Value { get; private set; }

        public DataPoint(string label, decimal value)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentException("Label não pode estar vazio", nameof(label));

            if (value < 0)
                throw new ArgumentException("Valor não pode ser negativo", nameof(value));

            Label = label;
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not DataPoint other)
                return false;

            return Label == other.Label && Value == other.Value;
        }

        public override int GetHashCode() => HashCode.Combine(Label, Value);

        public override string ToString() => $"{Label}: {Value}";
    }
}
