namespace WorkshopTemplate.Domain;

public sealed class FirstName : IEquatable<FirstName>
{
    private const int MaxLength = 30;
    
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("First name cannot be empty or whitespace.");
        }

        if (value.Length > MaxLength)
        {
            throw new ArgumentException($"First name cannot exceed {MaxLength} characters.");
        }

        if (value.Any(c => !char.IsLetter(c)))
        {
            throw new ArgumentException("First name must contain only letters.");
        }

        return new FirstName(value);
    }

    public bool Equals(FirstName? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as FirstName);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(FirstName? left, FirstName? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(FirstName? left, FirstName? right)
    {
        return !(left == right);
    }
}
