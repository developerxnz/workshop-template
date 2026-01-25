namespace WorkshopTemplate.Domain.Tests;

public class MobileNumberTests
{
    [Fact]
    public void Constructor_WithValidNzMobileNumber_CreatesMobileNumber()
    {
        // Arrange
        var number = "0211234567";

        // Act
        var mobileNumber = new MobileNumber(number);

        // Assert
        Assert.Equal("0211234567", mobileNumber.Number);
    }

    [Theory]
    [InlineData("0211234567")]
    [InlineData("0221234567")]
    [InlineData("0271234567")]
    [InlineData("0291234567")]
    [InlineData("0201234567")]
    public void Constructor_WithValidNzMobileNumbers_CreatesMobileNumber(string number)
    {
        // Act
        var mobileNumber = new MobileNumber(number);

        // Assert
        Assert.Equal(number, mobileNumber.Number);
    }

    [Fact]
    public void Constructor_WithSpacesInNumber_RemovesSpacesAndCreatesValid()
    {
        // Arrange
        var number = "021 123 4567";

        // Act
        var mobileNumber = new MobileNumber(number);

        // Assert
        Assert.Equal("0211234567", mobileNumber.Number);
    }

    [Fact]
    public void Constructor_WithDashesInNumber_RemovesDashesAndCreatesValid()
    {
        // Arrange
        var number = "021-123-4567";

        // Act
        var mobileNumber = new MobileNumber(number);

        // Assert
        Assert.Equal("0211234567", mobileNumber.Number);
    }

    [Fact]
    public void Constructor_TrimsWhitespace()
    {
        // Arrange & Act
        var mobileNumber = new MobileNumber("  0211234567  ");

        // Assert
        Assert.Equal("0211234567", mobileNumber.Number);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidValue_ThrowsArgumentException(string? invalidNumber)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new MobileNumber(invalidNumber!));
        Assert.Contains("Mobile number cannot be null or empty", exception.Message);
    }

    [Theory]
    [InlineData("123456789")]      // Too short
    [InlineData("12345678901")]    // Too long
    [InlineData("0111234567")]     // Doesn't start with 02
    [InlineData("0311234567")]     // Doesn't start with 02
    [InlineData("1211234567")]     // Doesn't start with 0
    [InlineData("021123456")]      // Too short (9 digits)
    [InlineData("02112345678")]    // Too long (11 digits)
    public void Constructor_WithInvalidFormat_ThrowsArgumentException(string invalidNumber)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new MobileNumber(invalidNumber));
        Assert.Contains("Mobile number must be a valid NZ mobile number", exception.Message);
    }

    [Fact]
    public void ToString_ReturnsFormattedNumber()
    {
        // Arrange
        var mobileNumber = new MobileNumber("0211234567");

        // Act
        var result = mobileNumber.ToString();

        // Assert
        Assert.Equal("021 123 4567", result);
    }

    [Fact]
    public void Equals_WithSameValues_ReturnsTrue()
    {
        // Arrange
        var mobileNumber1 = new MobileNumber("0211234567");
        var mobileNumber2 = new MobileNumber("0211234567");

        // Act & Assert
        Assert.True(mobileNumber1.Equals(mobileNumber2));
    }

    [Fact]
    public void Equals_WithDifferentValues_ReturnsFalse()
    {
        // Arrange
        var mobileNumber1 = new MobileNumber("0211234567");
        var mobileNumber2 = new MobileNumber("0227654321");

        // Act & Assert
        Assert.False(mobileNumber1.Equals(mobileNumber2));
    }

    [Fact]
    public void Equals_WithNull_ReturnsFalse()
    {
        // Arrange
        var mobileNumber = new MobileNumber("0211234567");

        // Act & Assert
        Assert.False(mobileNumber.Equals(null));
    }

    [Fact]
    public void GetHashCode_WithSameValues_ReturnsSameHash()
    {
        // Arrange
        var mobileNumber1 = new MobileNumber("0211234567");
        var mobileNumber2 = new MobileNumber("0211234567");

        // Act & Assert
        Assert.Equal(mobileNumber1.GetHashCode(), mobileNumber2.GetHashCode());
    }

    [Fact]
    public void PropertySetter_WithValidValue_UpdatesProperty()
    {
        // Arrange
        var mobileNumber = new MobileNumber("0211234567");

        // Act
        mobileNumber.Number = "0227654321";

        // Assert
        Assert.Equal("0227654321", mobileNumber.Number);
    }

    [Fact]
    public void PropertySetter_WithFormattedNumber_StoresDigitsOnly()
    {
        // Arrange
        var mobileNumber = new MobileNumber("0211234567");

        // Act
        mobileNumber.Number = "022 765 4321";

        // Assert
        Assert.Equal("0227654321", mobileNumber.Number);
    }

    [Fact]
    public void PropertySetter_TrimsWhitespace()
    {
        // Arrange
        var mobileNumber = new MobileNumber("0211234567");

        // Act
        mobileNumber.Number = "  0227654321  ";

        // Assert
        Assert.Equal("0227654321", mobileNumber.Number);
    }
}
