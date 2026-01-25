namespace WorkshopTemplate.Domain.Tests;

public class AddressTests
{
    [Fact]
    public void Constructor_WithValidParameters_CreatesAddress()
    {
        // Arrange
        var street = "123 Main Street";
        var suburb = "Central City";
        var postcode = "12345";
        var country = "New Zealand";

        // Act
        var address = new Address(street, suburb, postcode, country);

        // Assert
        Assert.Equal(street, address.Street);
        Assert.Equal(suburb, address.Suburb);
        Assert.Equal(postcode, address.Postcode);
        Assert.Equal(country, address.Country);
    }

    [Fact]
    public void Constructor_TrimsWhitespace()
    {
        // Arrange & Act
        var address = new Address("  123 Main Street  ", "  Central City  ", "  12345  ", "  New Zealand  ");

        // Assert
        Assert.Equal("123 Main Street", address.Street);
        Assert.Equal("Central City", address.Suburb);
        Assert.Equal("12345", address.Postcode);
        Assert.Equal("New Zealand", address.Country);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Street_WithInvalidValue_ThrowsArgumentException(string? invalidStreet)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address(invalidStreet!, "Central City", "12345", "New Zealand"));
        Assert.Contains("Street cannot be null or empty", exception.Message);
    }

    [Fact]
    public void Street_ExceedingMaxLength_ThrowsArgumentException()
    {
        // Arrange
        var tooLongStreet = new string('A', 201);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address(tooLongStreet, "Central City", "12345", "New Zealand"));
        Assert.Contains("Street cannot exceed 200 characters", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Suburb_WithInvalidValue_ThrowsArgumentException(string? invalidSuburb)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address("123 Main Street", invalidSuburb!, "12345", "New Zealand"));
        Assert.Contains("Suburb cannot be null or empty", exception.Message);
    }

    [Fact]
    public void Suburb_ExceedingMaxLength_ThrowsArgumentException()
    {
        // Arrange
        var tooLongSuburb = new string('B', 101);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address("123 Main Street", tooLongSuburb, "12345", "New Zealand"));
        Assert.Contains("Suburb cannot exceed 100 characters", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Postcode_WithInvalidValue_ThrowsArgumentException(string? invalidPostcode)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address("123 Main Street", "Central City", invalidPostcode!, "New Zealand"));
        Assert.Contains("Postcode cannot be null or empty", exception.Message);
    }

    [Fact]
    public void Postcode_ExceedingMaxLength_ThrowsArgumentException()
    {
        // Arrange
        var tooLongPostcode = new string('1', 21);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address("123 Main Street", "Central City", tooLongPostcode, "New Zealand"));
        Assert.Contains("Postcode cannot exceed 20 characters", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Country_WithInvalidValue_ThrowsArgumentException(string? invalidCountry)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address("123 Main Street", "Central City", "12345", invalidCountry!));
        Assert.Contains("Country cannot be null or empty", exception.Message);
    }

    [Fact]
    public void Country_ExceedingMaxLength_ThrowsArgumentException()
    {
        // Arrange
        var tooLongCountry = new string('C', 101);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => 
            new Address("123 Main Street", "Central City", "12345", tooLongCountry));
        Assert.Contains("Country cannot exceed 100 characters", exception.Message);
    }

    [Fact]
    public void ToString_ReturnsFormattedAddress()
    {
        // Arrange
        var address = new Address("123 Main Street", "Central City", "12345", "New Zealand");

        // Act
        var result = address.ToString();

        // Assert
        Assert.Equal("123 Main Street, Central City, 12345, New Zealand", result);
    }

    [Fact]
    public void Equals_WithSameValues_ReturnsTrue()
    {
        // Arrange
        var address1 = new Address("123 Main Street", "Central City", "12345", "New Zealand");
        var address2 = new Address("123 Main Street", "Central City", "12345", "New Zealand");

        // Act & Assert
        Assert.True(address1.Equals(address2));
    }

    [Fact]
    public void Equals_WithDifferentValues_ReturnsFalse()
    {
        // Arrange
        var address1 = new Address("123 Main Street", "Central City", "12345", "New Zealand");
        var address2 = new Address("456 Oak Avenue", "Westside", "67890", "Australia");

        // Act & Assert
        Assert.False(address1.Equals(address2));
    }

    [Fact]
    public void Equals_WithNull_ReturnsFalse()
    {
        // Arrange
        var address = new Address("123 Main Street", "Central City", "12345", "New Zealand");

        // Act & Assert
        Assert.False(address.Equals(null));
    }

    [Fact]
    public void GetHashCode_WithSameValues_ReturnsSameHash()
    {
        // Arrange
        var address1 = new Address("123 Main Street", "Central City", "12345", "New Zealand");
        var address2 = new Address("123 Main Street", "Central City", "12345", "New Zealand");

        // Act & Assert
        Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
    }

    [Fact]
    public void PropertySetters_WithValidValues_UpdateProperties()
    {
        // Arrange
        var address = new Address("123 Main Street", "Central City", "12345", "New Zealand");

        // Act
        address.Street = "456 Oak Avenue";
        address.Suburb = "Westside";
        address.Postcode = "67890";
        address.Country = "Australia";

        // Assert
        Assert.Equal("456 Oak Avenue", address.Street);
        Assert.Equal("Westside", address.Suburb);
        Assert.Equal("67890", address.Postcode);
        Assert.Equal("Australia", address.Country);
    }

    [Fact]
    public void PropertySetters_TrimsWhitespace()
    {
        // Arrange
        var address = new Address("123 Main Street", "Central City", "12345", "New Zealand");

        // Act
        address.Street = "  456 Oak Avenue  ";
        address.Suburb = "  Westside  ";
        address.Postcode = "  67890  ";
        address.Country = "  Australia  ";

        // Assert
        Assert.Equal("456 Oak Avenue", address.Street);
        Assert.Equal("Westside", address.Suburb);
        Assert.Equal("67890", address.Postcode);
        Assert.Equal("Australia", address.Country);
    }
}
