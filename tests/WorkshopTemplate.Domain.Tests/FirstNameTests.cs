using WorkshopTemplate.Domain;

namespace WorkshopTemplate.Domain.Tests;

public class FirstNameTests
{
    public static IEnumerable<object[]> ValidNames =>
        new List<object[]>
        {
            new object[] { "John" },
            new object[] { "Jane" },
            new object[] { new string('A', 30) },
            new object[] { "John Doe" },
            new object[] { "Mary-Jane" },
            new object[] { "O'Brien" }
        };

    public static IEnumerable<object[]> InvalidNamesWithNumbers =>
        new List<object[]>
        {
            new object[] { "John123" },
            new object[] { "1John" },
            new object[] { "Jo2hn" }
        };

    public static IEnumerable<object[]> InvalidNamesWithSpecialCharacters =>
        new List<object[]>
        {
            new object[] { "John@" }
        };

    [Theory]
    [MemberData(nameof(ValidNames))]
    public void Create_WithValidName_ReturnsFirstName(string name)
    {
        var firstName = FirstName.Create(name);
        
        Assert.NotNull(firstName);
        Assert.Equal(name, firstName.Value);
    }

    [Fact]
    public void Create_WithNameTooLong_ThrowsArgumentException()
    {
        var name = new string('A', 31);
        
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithEmptyOrWhitespace_ThrowsArgumentException(string? name)
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void Create_WithNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => FirstName.Create(null));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [MemberData(nameof(InvalidNamesWithNumbers))]
    public void Create_WithNumbers_ThrowsArgumentException(string name)
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [MemberData(nameof(InvalidNamesWithSpecialCharacters))]
    public void Create_WithSpecialCharacters_ThrowsArgumentException(string name)
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [InlineData(" John")]
    [InlineData("John ")]
    [InlineData(" John ")]
    public void Create_WithLeadingOrTrailingSpaces_ThrowsArgumentException(string name)
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [InlineData("---")]
    [InlineData("'''")]
    [InlineData(" - ")]
    public void Create_WithOnlySpecialCharacters_ThrowsArgumentException(string name)
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Fact]
    public void Equals_SameValue_ReturnsTrue()
    {
        var firstName1 = FirstName.Create("John");
        var firstName2 = FirstName.Create("John");
        
        Assert.Equal(firstName1, firstName2);
        Assert.True(firstName1.Equals(firstName2));
    }

    [Fact]
    public void Equals_DifferentValue_ReturnsFalse()
    {
        var firstName1 = FirstName.Create("John");
        var firstName2 = FirstName.Create("Jane");
        
        Assert.NotEqual(firstName1, firstName2);
        Assert.False(firstName1.Equals(firstName2));
    }

    [Fact]
    public void Equals_WithNull_ReturnsFalse()
    {
        var firstName = FirstName.Create("John");
        
        Assert.False(firstName.Equals(null));
    }

    [Fact]
    public void GetHashCode_SameValue_ReturnsSameHashCode()
    {
        var firstName1 = FirstName.Create("John");
        var firstName2 = FirstName.Create("John");
        
        Assert.Equal(firstName1.GetHashCode(), firstName2.GetHashCode());
    }

    [Fact]
    public void EqualityOperator_SameValue_ReturnsTrue()
    {
        var firstName1 = FirstName.Create("John");
        var firstName2 = FirstName.Create("John");
        
        Assert.True(firstName1 == firstName2);
    }

    [Fact]
    public void InequalityOperator_DifferentValue_ReturnsTrue()
    {
        var firstName1 = FirstName.Create("John");
        var firstName2 = FirstName.Create("Jane");
        
        Assert.True(firstName1 != firstName2);
    }

    [Fact]
    public void EqualityOperator_BothNull_ReturnsTrue()
    {
        FirstName? firstName1 = null;
        FirstName? firstName2 = null;
        
        Assert.True(firstName1 == firstName2);
    }

    [Fact]
    public void ToString_ReturnsValue()
    {
        var firstName = FirstName.Create("John");
        
        Assert.Equal("John", firstName.ToString());
    }
}
