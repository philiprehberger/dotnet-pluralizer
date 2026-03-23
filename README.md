# Philiprehberger.Pluralizer

[![CI](https://github.com/philiprehberger/dotnet-pluralizer/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-pluralizer/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.Pluralizer.svg)](https://www.nuget.org/packages/Philiprehberger.Pluralizer)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-pluralizer)](LICENSE)

Singularize and pluralize English words with irregular forms, uncountable words, and count-aware formatting.

## Installation

```bash
dotnet add package Philiprehberger.Pluralizer
```

## Usage

```csharp
using Philiprehberger.Pluralizer;

// Pluralize
Pluralizer.Pluralize("cat");       // "cats"
Pluralizer.Pluralize("bus");       // "buses"
Pluralizer.Pluralize("baby");      // "babies"
Pluralizer.Pluralize("wolf");      // "wolves"
Pluralizer.Pluralize("person");    // "people"
Pluralizer.Pluralize("child");     // "children"

// Singularize
Pluralizer.Singularize("cats");     // "cat"
Pluralizer.Singularize("buses");    // "bus"
Pluralizer.Singularize("babies");   // "baby"
Pluralizer.Singularize("wolves");   // "wolf"
Pluralizer.Singularize("people");   // "person"
Pluralizer.Singularize("children"); // "child"

// Count-aware formatting
Pluralizer.Format(0, "item");  // "0 items"
Pluralizer.Format(1, "item");  // "1 item"
Pluralizer.Format(5, "item");  // "5 items"
Pluralizer.Format(1, "person"); // "1 person"
Pluralizer.Format(3, "person"); // "3 people"

// Detection
Pluralizer.IsPlural("cats");    // true
Pluralizer.IsSingular("cat");   // true
Pluralizer.IsPlural("sheep");   // true (uncountable)
Pluralizer.IsSingular("sheep"); // true (uncountable)

// Custom rules
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
| `IsPlural(string word)` | Check if a word is in plural form |
| `IsSingular(string word)` | Check if a word is in singular form |
| `AddIrregular(string singular, string plural)` | Register a custom irregular word pair |
| `AddUncountable(string word)` | Register a word as uncountable |

## Development

```bash
dotnet build src/Philiprehberger.Pluralizer.csproj --configuration Release
```

## License

MIT
