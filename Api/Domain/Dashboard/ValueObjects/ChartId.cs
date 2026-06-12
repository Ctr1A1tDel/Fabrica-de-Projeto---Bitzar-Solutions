namespace Api.Domain.Dashboard.ValueObjects
{
    public class ChartId
    {
        public Guid Value { get; private set; }

        public ChartId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("ChartId não pode estar vazio", nameof(value));

            Value = value;
        }

        public static ChartId New() => new(Guid.NewGuid());

        public override bool Equals(object? obj)
        {
            if (obj is not ChartId other)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();
    }
}
