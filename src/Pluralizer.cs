using System.Text.RegularExpressions;

namespace Philiprehberger.Pluralizer;

/// <summary>
/// Provides static methods for singularizing and pluralizing English words,
/// with support for irregular forms, uncountable words, and count-aware formatting.
/// </summary>
public static class Pluralizer
{
    private static readonly object Lock = new();

    /// <summary>
    /// Converts a singular English word to its plural form.
    /// </summary>
    /// <param name="word">The singular word to pluralize.</param>
    /// <returns>The plural form of the word.</returns>
    public static string Pluralize(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        if (string.IsNullOrWhiteSpace(word))
        {
            return word;
        }

        lock (Lock)
        {
            if (Uncountables.IsUncountable(word))
            {
                return word;
            }

            if (Irregulars.TryGetPlural(word, out var irregular))
            {
                return PreserveCase(word, irregular);
            }

            return Rules.ApplyPluralRules(word);
        }
    }

    /// <summary>
    /// Converts a plural English word to its singular form.
    /// </summary>
    /// <param name="word">The plural word to singularize.</param>
    /// <returns>The singular form of the word.</returns>
    public static string Singularize(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        if (string.IsNullOrWhiteSpace(word))
        {
            return word;
        }

        lock (Lock)
        {
            if (Uncountables.IsUncountable(word))
            {
                return word;
            }

            if (Irregulars.TryGetSingular(word, out var irregular))
            {
                return PreserveCase(word, irregular);
            }

            return Rules.ApplySingularRules(word);
        }
    }

    /// <summary>
    /// Formats a count and word into a string like "1 item" or "3 items",
    /// automatically choosing the singular or plural form based on the count.
    /// </summary>
    /// <param name="count">The number of items.</param>
    /// <param name="word">The word to format (in singular form).</param>
    /// <returns>A formatted string with the count and the correct word form.</returns>
    public static string Format(int count, string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        string form = count == 1 ? Singularize(word) : Pluralize(word);
        return $"{count} {form}";
    }

    /// <summary>
    /// Determines whether the specified word is in plural form.
    /// Uncountable words are considered both singular and plural.
    /// </summary>
    /// <param name="word">The word to check.</param>
    /// <returns><c>true</c> if the word is plural; otherwise, <c>false</c>.</returns>
    public static bool IsPlural(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        if (string.IsNullOrWhiteSpace(word))
        {
            return false;
        }

        lock (Lock)
        {
            if (Uncountables.IsUncountable(word))
            {
                return true;
            }

            // A word is plural if singularizing it produces a different word
            // and pluralizing that singular form gives back the original
            string singular = Singularize(word);
            if (string.Equals(singular, word, StringComparison.OrdinalIgnoreCase))
            {
                // Singularize didn't change it; check if pluralizing changes it
                string plural = Pluralize(word);
                return !string.Equals(plural, word, StringComparison.OrdinalIgnoreCase);
            }

            // Singularize changed it, so the original was plural
            return true;
        }
    }

    /// <summary>
    /// Determines whether the specified word is in singular form.
    /// Uncountable words are considered both singular and plural.
    /// </summary>
    /// <param name="word">The word to check.</param>
    /// <returns><c>true</c> if the word is singular; otherwise, <c>false</c>.</returns>
    public static bool IsSingular(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        if (string.IsNullOrWhiteSpace(word))
        {
            return false;
        }

        lock (Lock)
        {
            if (Uncountables.IsUncountable(word))
            {
                return true;
            }

            // A word is singular if pluralizing it produces a different word
            string plural = Pluralize(word);
            if (string.Equals(plural, word, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    /// Registers a custom irregular singular/plural word pair.
    /// </summary>
    /// <param name="singular">The singular form of the word.</param>
    /// <param name="plural">The plural form of the word.</param>
    public static void AddIrregular(string singular, string plural)
    {
        ArgumentNullException.ThrowIfNull(singular);
        ArgumentNullException.ThrowIfNull(plural);

        lock (Lock)
        {
            Irregulars.Add(singular, plural);
        }
    }

    /// <summary>
    /// Converts an integer to its ordinal string representation (e.g., 1 → "1st", 2 → "2nd", 3 → "3rd", 4 → "4th").
    /// Handles special cases for 11th, 12th, 13th and negative numbers.
    /// </summary>
    /// <param name="number">The integer to ordinalize.</param>
    /// <returns>The ordinal string representation of the number.</returns>
    public static string Ordinalize(int number)
    {
        var abs = Math.Abs(number);
        var lastTwo = abs % 100;
        var lastOne = abs % 10;
        var suffix = (lastTwo >= 11 && lastTwo <= 13) ? "th"
            : lastOne == 1 ? "st"
            : lastOne == 2 ? "nd"
            : lastOne == 3 ? "rd"
            : "th";
        return $"{number}{suffix}";
    }

    /// <summary>
    /// Registers a word as uncountable (same form for singular and plural).
    /// </summary>
    /// <param name="word">The uncountable word to register.</param>
    public static void AddUncountable(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        lock (Lock)
        {
            Uncountables.Add(word);
        }
    }

    private static string PreserveCase(string original, string replacement)
    {
        if (string.IsNullOrEmpty(original) || string.IsNullOrEmpty(replacement))
        {
            return replacement;
        }

        if (original.All(char.IsUpper))
        {
            return replacement.ToUpperInvariant();
        }

        if (char.IsUpper(original[0]))
        {
            return char.ToUpperInvariant(replacement[0]) + replacement[1..];
        }

        return replacement.ToLowerInvariant();
    }
}
