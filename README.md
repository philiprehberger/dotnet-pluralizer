# Philiprehberger.Pluralizer

[![CI](https://github.com/philiprehberger/dotnet-pluralizer/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-pluralizer/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.Pluralizer.svg)](https://www.nuget.org/packages/Philiprehberger.Pluralizer)
[![Last updated](https://img.shields.io/github/last-commit/philiprehberger/dotnet-pluralizer)](https://github.com/philiprehberger/dotnet-pluralizer/commits/main)

Singularize and pluralize English words with irregular forms, uncountable words, count-aware formatting, and ordinal number conversion.

## Installation

```bash
dotnet add package Philiprehberger.Pluralizer
```

## Usage

### Pluralize and Singularize

```csharp
using Philiprehberger.Pluralizer;

Pluralizer.Pluralize("cat");       // "cats"
Pluralizer.Pluralize("baby");      // "babies"
Pluralizer.Pluralize("person");    // "people"
Pluralizer.Pluralize("child");     // "children"

Pluralizer.Singularize("buses");    // "bus"
Pluralizer.Singularize("wolves");   // "wolf"
Pluralizer.Singularize("people");   // "person"
Pluralizer.Singularize("children"); // "child"
```

### Count-Aware Formatting and Detection

```csharp
using Philiprehberger.Pluralizer;

Pluralizer.Format(0, "item");   // "0 items"
Pluralizer.Format(1, "item");   // "1 item"
Pluralizer.Format(5, "item");   // "5 items"
Pluralizer.Format(1, "person"); // "1 person"
Pluralizer.Format(3, "person"); // "3 people"

Pluralizer.IsPlural("cats");    // true
Pluralizer.IsSingular("cat");   // true
Pluralizer.IsPlural("sheep");   // true (uncountable)
```

### Ordinalize Numbers

```csharp
using Philiprehberger.Pluralizer;

Pluralizer.Ordinalize(1);   // "1st"
Pluralizer.Ordinalize(2);   // "2nd"
Pluralizer.Ordinalize(3);   // "3rd"
Pluralizer.Ordinalize(4);   // "4th"
Pluralizer.Ordinalize(11);  // "11th"
Pluralizer.Ordinalize(21);  // "21st"
Pluralizer.Ordinalize(113); // "113th"
```

### Custom Rules

```csharp
using Philiprehberger.Pluralizer;

Pluralizer.AddIrregular("cactus", "cacti");
Pluralizer.Pluralize("cactus"); // "cacti"

Pluralizer.AddUncountable("software");
Pluralizer.Pluralize("software"); // "software"
```

## API

### `Pluralizer`

| Member | Description |
|--------|-------------|
| `Pluralize(string word)` | Convert a singular word to its plural form |
| `Singularize(string word)` | Convert a plural word to its singular form |
| `Format(int count, string word)` | Format as "count word(s)" using the correct form |
| `Ordinalize(int number)` | Convert an integer to its ordinal string (1 → "1st", 2 → "2nd") |
| `IsPlural(string word)` | Check if a word is in plural form |
| `IsSingular(string word)` | Check if a word is in singular form |
| `AddIrregular(string singular, string plural)` | Register a custom irregular word pair |
| `AddUncountable(string word)` | Register a word as uncountable |

## Development

```bash
dotnet build src/Philiprehberger.Pluralizer.csproj --configuration Release
```

## Support

If you find this project useful:

⭐ [Star the repo](https://github.com/philiprehberger/dotnet-pluralizer)

🐛 [Report issues](https://github.com/philiprehberger/dotnet-pluralizer/issues?q=is%3Aissue+is%3Aopen+label%3Abug)

💡 [Suggest features](https://github.com/philiprehberger/dotnet-pluralizer/issues?q=is%3Aissue+is%3Aopen+label%3Aenhancement)

❤️ [Sponsor development](https://github.com/sponsors/philiprehberger)

🌐 [All Open Source Projects](https://philiprehberger.com/open-source-packages)

💻 [GitHub Profile](https://github.com/philiprehberger)

🔗 [LinkedIn Profile](https://www.linkedin.com/in/philiprehberger)

## License

[MIT](LICENSE)
