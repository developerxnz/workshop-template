namespace WorkshopTemplate.Domain;

/// <summary>
/// Represents a physical address with validation rules
/// </summary>
public sealed record Address
{
    /// <summary>
    /// Gets the street address
    /// </summary>
    public string Street { get; }

    /// <summary>
    /// Gets the suburb
    /// </summary>
    public string Suburb { get; }

    /// <summary>
    /// Gets the postcode
    /// </summary>
    public string Postcode { get; }

    /// <summary>
    /// Gets the country
    /// </summary>
    public string Country { get; }

    private Address(string street, string suburb, string postcode, string country)
    {
        Street = street;
        Suburb = suburb;
        Postcode = postcode;
        Country = country;
    }

    /// <summary>
    /// Creates a new Address instance with validation
    /// </summary>
    /// <param name="street">Street address</param>
    /// <param name="suburb">Suburb</param>
    /// <param name="postcode">Postcode</param>
    /// <param name="country">Country</param>
    public static Address Create(string street, string suburb, string postcode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or empty", nameof(street));
        var trimmedStreet = street.Trim();
        if (trimmedStreet.Length > 200)
            throw new ArgumentException("Street cannot exceed 200 characters", nameof(street));

        if (string.IsNullOrWhiteSpace(suburb))
            throw new ArgumentException("Suburb cannot be null or empty", nameof(suburb));
        var trimmedSuburb = suburb.Trim();
        if (trimmedSuburb.Length > 100)
            throw new ArgumentException("Suburb cannot exceed 100 characters", nameof(suburb));

        if (string.IsNullOrWhiteSpace(postcode))
            throw new ArgumentException("Postcode cannot be null or empty", nameof(postcode));
        var trimmedPostcode = postcode.Trim();
        if (trimmedPostcode.Length > 20)
            throw new ArgumentException("Postcode cannot exceed 20 characters", nameof(postcode));

        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or empty", nameof(country));
        var trimmedCountry = country.Trim();
        if (trimmedCountry.Length > 100)
            throw new ArgumentException("Country cannot exceed 100 characters", nameof(country));

        return new Address(trimmedStreet, trimmedSuburb, trimmedPostcode, trimmedCountry);
    }

    /// <summary>
    /// Returns the full address as a formatted string
    /// </summary>
    public override string ToString()
    {
        return $"{Street}, {Suburb}, {Postcode}, {Country}";
    }
}
