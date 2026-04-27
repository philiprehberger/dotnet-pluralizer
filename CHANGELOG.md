# Changelog

## 0.3.0 (2026-04-27)

- Add `Titleize(text)` and `Titleize(count, text)` for headline-style capitalization with count-aware pluralization
- Add `ToOrdinalWords(int)` returning spelled-out ordinals for `0..999` (e.g. 23 → "twenty-third")
- Fix consonant-y pluralization regex (`baby` → `babies`, was `babys` due to a stray `}` in the pattern)
- Fix `IsPlural` returning `true` for clearly-singular words like `cat`; logic now treats both forms unchanged as plural-equivalent
- Add xUnit test project under `tests/Philiprehberger.Pluralizer.Tests/` with broad coverage for every public method
- Add `dotnet test` step to the CI workflow and pin `actions/checkout@v5`
- Normalize CHANGELOG entry header for `0.2.0` to the standard `## X.Y.Z (YYYY-MM-DD)` format

## 0.2.0 (2026-04-05)

- Add `Pluralizer.Ordinalize(int number)` method for converting integers to ordinal strings (1st, 2nd, 3rd, 4th, 11th, 21st, etc.)

## 0.1.2 (2026-03-31)

- Standardize README to 3-badge format with emoji Support section
- Update CI actions to v5 for Node.js 24 compatibility
- Add GitHub issue templates, dependabot config, and PR template

## 0.1.1 (2026-03-24)

- Expand README usage section with feature subsections

## 0.1.0 (2026-03-22)

- Initial release
- `Pluralizer.Pluralize` and `Pluralizer.Singularize` for English words
- `Pluralizer.Format` for count-aware formatting (e.g. "1 item", "3 items")
- `Pluralizer.IsPlural` and `Pluralizer.IsSingular` detection
- `Pluralizer.AddIrregular` and `Pluralizer.AddUncountable` for custom rules
- Built-in irregular forms (person/people, child/children, etc.)
- Built-in uncountable words (equipment, information, sheep, etc.)
