using WorkshopTemplate.Domain;

namespace WorkshopTemplate.Domain.Tests;

public class BirthDateTests
{
    public static IEnumerable<object[]> ValidBirthDates =>
        new List<object[]>
        {
            new object[] { DateTime.Today.AddYears(-1) },
            new object[] { DateTime.Today.AddYears(-25) },
            new object[] { DateTime.Today.AddYears(-50) },
            new object[] { DateTime.Today.AddYears(-100) },
            new object[] { DateTime.Today.AddYears(-105) },
            new object[] { DateTime.Today },
            new object[] { new DateTime(2000, 1, 1) },
            new object[] { new DateTime(1990, 6, 15) }
        };

    public static IEnumerable<object[]> FutureDates =>
        new List<object[]>
        {
            new object[] { DateTime.Today.AddDays(1) },
            new object[] { DateTime.Today.AddMonths(1) },
            new object[] { DateTime.Today.AddYears(1) },
            new object[] { new DateTime(2100, 1, 1) }
        };

    public static IEnumerable<object[]> TooOldDates =>
        new List<object[]>
        {
            new object[] { DateTime.Today.AddYears(-106) },
            new object[] { DateTime.Today.AddYears(-150) },
            new object[] { DateTime.Today.AddYears(-200) },
            new object[] { new DateTime(1900, 1, 1) }
        };

    [Theory]
    [MemberData(nameof(ValidBirthDates))]
    public void Create_WithValidDate_ReturnsBirthDate(DateTime date)
    {
        var birthDate = BirthDate.Create(date);
        
        Assert.NotNull(birthDate);
        Assert.Equal(date.Date, birthDate.Value);
    }

    [Fact]
    public void Create_WithNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => BirthDate.Create(null));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [MemberData(nameof(FutureDates))]
    public void Create_WithFutureDate_ThrowsArgumentException(DateTime date)
    {
        var exception = Assert.Throws<ArgumentException>(() => BirthDate.Create(date));
        
        Assert.Equal("value", exception.ParamName);
        Assert.Contains("future", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Theory]
    [MemberData(nameof(TooOldDates))]
    public void Create_WithDateOlderThan105Years_ThrowsArgumentException(DateTime date)
    {
        var exception = Assert.Throws<ArgumentException>(() => BirthDate.Create(date));
        
        Assert.Equal("value", exception.ParamName);
        Assert.Contains("105", exception.Message);
    }

    [Fact]
    public void Create_WithExactly105YearsOld_ReturnsBirthDate()
    {
        var date = DateTime.Today.AddYears(-105);
        
        var birthDate = BirthDate.Create(date);
        
        Assert.NotNull(birthDate);
        Assert.Equal(date.Date, birthDate.Value);
    }

    [Fact]
    public void Create_WithToday_ReturnsBirthDate()
    {
        var today = DateTime.Today;
        
        var birthDate = BirthDate.Create(today);
        
        Assert.NotNull(birthDate);
        Assert.Equal(today, birthDate.Value);
    }

    [Fact]
    public void Create_StoresDateWithoutTime()
    {
        var dateWithTime = new DateTime(2000, 1, 1, 15, 30, 45);
        
        var birthDate = BirthDate.Create(dateWithTime);
        
        Assert.Equal(new DateTime(2000, 1, 1), birthDate.Value);
        Assert.Equal(TimeSpan.Zero, birthDate.Value.TimeOfDay);
    }

    [Fact]
    public void Equals_SameValue_ReturnsTrue()
    {
        var date = new DateTime(2000, 1, 1);
        var birthDate1 = BirthDate.Create(date);
        var birthDate2 = BirthDate.Create(date);
        
        Assert.Equal(birthDate1, birthDate2);
        Assert.True(birthDate1.Equals(birthDate2));
    }

    [Fact]
    public void Equals_DifferentValue_ReturnsFalse()
    {
        var birthDate1 = BirthDate.Create(new DateTime(2000, 1, 1));
        var birthDate2 = BirthDate.Create(new DateTime(2000, 1, 2));
        
        Assert.NotEqual(birthDate1, birthDate2);
        Assert.False(birthDate1.Equals(birthDate2));
    }

    [Fact]
    public void Equals_WithNull_ReturnsFalse()
    {
        var birthDate = BirthDate.Create(new DateTime(2000, 1, 1));
        
        Assert.False(birthDate.Equals(null));
    }

    [Fact]
    public void GetHashCode_SameValue_ReturnsSameHashCode()
    {
        var date = new DateTime(2000, 1, 1);
        var birthDate1 = BirthDate.Create(date);
        var birthDate2 = BirthDate.Create(date);
        
        Assert.Equal(birthDate1.GetHashCode(), birthDate2.GetHashCode());
    }

    [Fact]
    public void EqualityOperator_SameValue_ReturnsTrue()
    {
        var date = new DateTime(2000, 1, 1);
        var birthDate1 = BirthDate.Create(date);
        var birthDate2 = BirthDate.Create(date);
        
        Assert.True(birthDate1 == birthDate2);
    }

    [Fact]
    public void InequalityOperator_DifferentValue_ReturnsTrue()
    {
        var birthDate1 = BirthDate.Create(new DateTime(2000, 1, 1));
        var birthDate2 = BirthDate.Create(new DateTime(2000, 1, 2));
        
        Assert.True(birthDate1 != birthDate2);
    }

    [Fact]
    public void EqualityOperator_BothNull_ReturnsTrue()
    {
        BirthDate? birthDate1 = null;
        BirthDate? birthDate2 = null;
        
        Assert.True(birthDate1 == birthDate2);
    }

    [Fact]
    public void ToString_ReturnsFormattedDate()
    {
        var birthDate = BirthDate.Create(new DateTime(2000, 1, 15));
        
        Assert.Equal("2000-01-15", birthDate.ToString());
    }
}
