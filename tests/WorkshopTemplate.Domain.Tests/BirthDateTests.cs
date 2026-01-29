using WorkshopTemplate.Domain;

namespace WorkshopTemplate.Domain.Tests;

public class BirthDateTests
{
    public static IEnumerable<object[]> ValidBirthDates =>
        new List<object[]>
        {
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-1)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-25)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-50)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-100)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-105)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today) },
            new object[] { new DateOnly(2000, 1, 1) },
            new object[] { new DateOnly(1990, 6, 15) }
        };

    public static IEnumerable<object[]> FutureDates =>
        new List<object[]>
        {
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddDays(1)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddMonths(1)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(1)) },
            new object[] { new DateOnly(2100, 1, 1) }
        };

    public static IEnumerable<object[]> TooOldDates =>
        new List<object[]>
        {
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-106)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-150)) },
            new object[] { DateOnly.FromDateTime(DateTime.Today.AddYears(-200)) },
            new object[] { new DateOnly(1900, 1, 1) }
        };

    [Theory]
    [MemberData(nameof(ValidBirthDates))]
    public void Create_WithValidDate_ReturnsBirthDate(DateOnly date)
    {
        var birthDate = BirthDate.Create(date);
        
        Assert.NotNull(birthDate);
        Assert.Equal(date, birthDate.Value);
    }

    [Fact]
    public void Create_WithNull_ThrowsArgumentNullException()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => BirthDate.Create(null));
        
        Assert.Equal("value", exception.ParamName);
    }

    [Theory]
    [MemberData(nameof(FutureDates))]
    public void Create_WithFutureDate_ThrowsArgumentException(DateOnly date)
    {
        var exception = Assert.Throws<ArgumentException>(() => BirthDate.Create(date));
        
        Assert.Equal("value", exception.ParamName);
        Assert.Contains("future", exception.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Theory]
    [MemberData(nameof(TooOldDates))]
    public void Create_WithDateOlderThan105Years_ThrowsArgumentException(DateOnly date)
    {
        var exception = Assert.Throws<ArgumentException>(() => BirthDate.Create(date));
        
        Assert.Equal("value", exception.ParamName);
        Assert.Contains("105", exception.Message);
    }

    [Fact]
    public void Create_WithExactly105YearsOld_ReturnsBirthDate()
    {
        var date = DateOnly.FromDateTime(DateTime.Today.AddYears(-105));
        
        var birthDate = BirthDate.Create(date);
        
        Assert.NotNull(birthDate);
        Assert.Equal(date, birthDate.Value);
    }

    [Fact]
    public void Create_WithToday_ReturnsBirthDate()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        
        var birthDate = BirthDate.Create(today);
        
        Assert.NotNull(birthDate);
        Assert.Equal(today, birthDate.Value);
    }

    [Fact]
    public void ToString_ReturnsFormattedDate()
    {
        var birthDate = BirthDate.Create(new DateOnly(2000, 1, 15));
        
        Assert.Equal("2000-01-15", birthDate.ToString());
    }
}
