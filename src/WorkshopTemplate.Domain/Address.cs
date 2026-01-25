namespace WorkshopTemplate.Domain;

/// <summary>
/// Represents a physical address with validation rules
/// </summary>
public class Address
{
    private string _street = null!;
    private string _suburb = null!;
    private string _postcode = null!;
    private string _country = null!;

    /// <summary>
    /// Gets or sets the street address
    /// </summary>
    public string Street
    {
        get => _street;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Street cannot be null or empty", nameof(Street));
            var trimmedValue = value.Trim();
            if (trimmedValue.Length > 200)
                throw new ArgumentException("Street cannot exceed 200 characters", nameof(Street));
            _street = trimmedValue;
        }
    }

    /// <summary>
    /// Gets or sets the suburb
    /// </summary>
    public string Suburb
    {
        get => _suburb;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Suburb cannot be null or empty", nameof(Suburb));
            var trimmedValue = value.Trim();
            if (trimmedValue.Length > 100)
                throw new ArgumentException("Suburb cannot exceed 100 characters", nameof(Suburb));
            _suburb = trimmedValue;
        }
    }

    /// <summary>
    /// Gets or sets the postcode
    /// </summary>
    public string Postcode
    {
        get => _postcode;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Postcode cannot be null or empty", nameof(Postcode));
            var trimmedValue = value.Trim();
            if (trimmedValue.Length > 20)
                throw new ArgumentException("Postcode cannot exceed 20 characters", nameof(Postcode));
            _postcode = trimmedValue;
        }
    }

    /// <summary>
    /// Gets or sets the country
    /// </summary>
    public string Country
    {
        get => _country;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Country cannot be null or empty", nameof(Country));
            var trimmedValue = value.Trim();
            if (trimmedValue.Length > 100)
                throw new ArgumentException("Country cannot exceed 100 characters", nameof(Country));
            _country = trimmedValue;
        }
    }

    /// <summary>
    /// Creates a new Address instance
    /// </summary>
    /// <param name="street">Street address</param>
    /// <param name="suburb">Suburb</param>
    /// <param name="postcode">Postcode</param>
    /// <param name="country">Country</param>
    public Address(string street, string suburb, string postcode, string country)
    {
        Street = street;
        Suburb = suburb;
        Postcode = postcode;
        Country = country;
    }

    /// <summary>
    /// Returns the full address as a formatted string
    /// </summary>
    public override string ToString()
    {
        return $"{Street}, {Suburb}, {Postcode}, {Country}";
    }

    /// <summary>
    /// Determines whether two Address instances are equal
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not Address other)
            return false;

        return Street == other.Street &&
               Suburb == other.Suburb &&
               Postcode == other.Postcode &&
               Country == other.Country;
    }

    /// <summary>
    /// Returns the hash code for this Address
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(Street, Suburb, Postcode, Country);
    }
}
