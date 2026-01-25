namespace WorkshopTemplate.Domain;

public sealed record FirstName
{
    private const int MaxLength = 30;
    
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName Create(string? value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("First name cannot be empty or whitespace.", nameof(value));
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"First name cannot exceed {MaxLength} characters.", nameof(value));
        }

        if (value.Any(c => !char.IsLetter(c)))
        {
            throw new ArgumentException("First name must contain only letters.", nameof(value));
        }

        return new FirstName(value);
    }

    public override string ToString()
    {
        return Value;
    }
}
