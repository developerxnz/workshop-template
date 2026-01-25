using WorkshopTemplate.Domain;

namespace WorkshopTemplate.Domain.Tests;

public class FirstNameTests
{
    [Fact]
    public void Create_WithValidName_ReturnsFirstName()
    {
        var firstName = FirstName.Create("John");
        
        Assert.NotNull(firstName);
        Assert.Equal("John", firstName.Value);
    }

    [Fact]
    public void Create_WithMaxLengthName_ReturnsFirstName()
    {
        var name = new string('A', 30);
        
        var firstName = FirstName.Create(name);
        
        Assert.NotNull(firstName);
        Assert.Equal(name, firstName.Value);
    }

    [Fact]
    public void Create_WithNameTooLong_ThrowsArgumentException()
    {
        var name = new string('A', 31);
        
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(name));
        
        Assert.Contains("cannot exceed 30 characters", exception.Message);
    }

    [Fact]
    public void Create_WithEmptyString_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(""));
        
        Assert.Contains("cannot be empty or whitespace", exception.Message);
    }

    [Fact]
    public void Create_WithWhitespace_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create("   "));
        
        Assert.Contains("cannot be empty or whitespace", exception.Message);
    }

    [Fact]
    public void Create_WithNull_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create(null!));
        
        Assert.Contains("cannot be empty or whitespace", exception.Message);
    }

    [Fact]
    public void Create_WithNumbers_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create("John123"));
        
        Assert.Contains("must contain only letters", exception.Message);
    }

    [Fact]
    public void Create_WithSpecialCharacters_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create("John@"));
        
        Assert.Contains("must contain only letters", exception.Message);
    }

    [Fact]
    public void Create_WithSpaces_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create("John Doe"));
        
        Assert.Contains("must contain only letters", exception.Message);
    }

    [Fact]
    public void Create_WithHyphen_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create("Mary-Jane"));
        
        Assert.Contains("must contain only letters", exception.Message);
    }

    [Fact]
    public void Create_WithApostrophe_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() => FirstName.Create("O'Brien"));
        
        Assert.Contains("must contain only letters", exception.Message);
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
