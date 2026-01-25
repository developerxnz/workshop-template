using System.Text.RegularExpressions;

namespace WorkshopTemplate.Domain;

/// <summary>
/// Represents a New Zealand mobile phone number with validation rules
/// </summary>
public class MobileNumber
{
    private static readonly Regex NzMobilePattern = new Regex(@"^02\d{8}$", RegexOptions.Compiled);
    private string _number = null!;

    /// <summary>
    /// Gets or sets the mobile number
    /// </summary>
    public string Number
    {
        get => _number;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Mobile number cannot be null or empty", nameof(Number));
            
            var trimmedValue = value.Trim();
            var digitsOnly = Regex.Replace(trimmedValue, @"[^\d]", "");
            
            if (!NzMobilePattern.IsMatch(digitsOnly))
                throw new ArgumentException("Mobile number must be a valid NZ mobile number (10 digits starting with 02)", nameof(Number));
            
            _number = digitsOnly;
        }
    }

    /// <summary>
    /// Creates a new MobileNumber instance
    /// </summary>
    /// <param name="number">The mobile phone number</param>
    public MobileNumber(string number)
    {
        Number = number;
    }

    /// <summary>
    /// Returns the mobile number in formatted form (02X XXX XXXX)
    /// </summary>
    public override string ToString()
    {
        if (_number.Length == 10)
        {
            return $"{_number.Substring(0, 3)} {_number.Substring(3, 3)} {_number.Substring(6, 4)}";
        }
        return _number;
    }

    /// <summary>
    /// Determines whether two MobileNumber instances are equal
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not MobileNumber other)
            return false;

        return Number == other.Number;
    }

    /// <summary>
    /// Returns the hash code for this MobileNumber
    /// </summary>
    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }
}
