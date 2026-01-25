# workshop-template

## Introduction
This workshop demonstrates domain-driven design with a focus on creating robust domain types with validation rules. The project includes an Address domain type with comprehensive validation.

## Prerequisite
- .NET 10 SDK or later
- Basic understanding of C# and object-oriented programming
- Familiarity with domain-driven design concepts

## Steps

### Step 1: Build the Solution
```bash
dotnet build
```

### Step 2: Run the Tests
```bash
dotnet test
```

### Step 3: Understanding the Address Domain Type
The `Address` class is located in `src/WorkshopTemplate.Domain/Address.cs` and includes:

**Properties:**
- `Street` - Street address (max 200 characters)
- `Suburb` - Suburb name (max 100 characters)
- `Postcode` - Postal code (max 20 characters)
- `Country` - Country name (max 100 characters)

**Validation Rules:**
- All fields are required (cannot be null or empty)
- All fields trim whitespace automatically
- Each field has a maximum length constraint
- Validation occurs on both construction and property setting

**Example Usage:**
```csharp
var address = new Address(
    "123 Main Street",
    "Central City",
    "12345",
    "New Zealand"
);

Console.WriteLine(address.ToString());
// Output: 123 Main Street, Central City, 12345, New Zealand
```

## Resources
- [.NET SDK Downloads](https://dotnet.microsoft.com/download)
- [Domain-Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)
- [xUnit Testing Framework](https://xunit.net/)

## Contact details
This is optional
