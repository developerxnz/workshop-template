# workshop-template

## Introduction
This workshop demonstrates domain-driven design with a focus on creating robust domain types with validation rules. The project includes a MobileNumber domain type with comprehensive validation for New Zealand mobile numbers.

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

### Step 3: Understanding the MobileNumber Domain Type
The `MobileNumber` class is located in `src/WorkshopTemplate.Domain/MobileNumber.cs` and includes:

**Properties:**
- `Number` - The mobile phone number (stored as digits only)

**Validation Rules:**
- Cannot be null or empty
- Must be a valid NZ mobile number format
- Must be exactly 10 digits
- Must start with "02" (NZ mobile prefix)
- Automatically strips non-digit characters (spaces, dashes)
- Trims whitespace automatically

**Example Usage:**
```csharp
// Create with plain digits
var mobile1 = new MobileNumber("0211234567");

// Create with formatting (automatically stripped)
var mobile2 = new MobileNumber("021 123 4567");
var mobile3 = new MobileNumber("021-123-4567");

// Display formatted number
Console.WriteLine(mobile1.ToString());
// Output: 021 123 4567
```

**Valid NZ Mobile Prefixes:**
- 020, 021, 022, 027, 028, 029 (and other 02X variants)

## Resources
- [.NET SDK Downloads](https://dotnet.microsoft.com/download)
- [Domain-Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)
- [xUnit Testing Framework](https://xunit.net/)

## Contact details
This is optional
