namespace WorkshopTemplate.Domain;

public sealed record BirthDate
{
    private const int MaxAgeYears = 105;
    
    public DateTime Value { get; }

    private BirthDate(DateTime value)
    {
        Value = value;
    }

    public static BirthDate Create(DateTime? value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var today = DateTime.Today;
        
        if (value.Value.Date > today)
        {
            throw new ArgumentException("Birth date cannot be in the future.", nameof(value));
        }

        var age = today.Year - value.Value.Year;
        // Adjust if birthday hasn't occurred yet this year
        if (value.Value.Date > today.AddYears(-age))
        {
            age--;
        }

        if (age > MaxAgeYears)
        {
            throw new ArgumentException($"Birth date cannot be older than {MaxAgeYears} years.", nameof(value));
        }

        return new BirthDate(value.Value.Date);
    }

    public override string ToString()
    {
        return Value.ToString("yyyy-MM-dd");
    }
}
