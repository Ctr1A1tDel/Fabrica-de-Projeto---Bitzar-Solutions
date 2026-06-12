namespace Api.Domain.Dashboard.ValueObjects
{
    public class DashboardId
    {
        public Guid Value { get; private set; }

        public DashboardId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("DashboardId não pode estar vazio", nameof(value));

            Value = value;
        }

        public static DashboardId New() => new(Guid.NewGuid());

        public override bool Equals(object? obj)
        {
            if (obj is not DashboardId other)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();
    }
}
