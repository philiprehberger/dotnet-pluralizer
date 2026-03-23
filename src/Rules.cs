using System.Text.RegularExpressions;

namespace Philiprehberger.Pluralizer;

/// <summary>
/// Contains ordered lists of regex-based rules for pluralization and singularization.
/// </summary>
internal static class Rules
{
    private static readonly List<(Regex Pattern, string Replacement)> PluralRules =
    [
        (new Regex(@"(quiz)$", RegexOptions.IgnoreCase), "$1zes"),
        (new Regex(@"^(oxen)$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"^(ox)$", RegexOptions.IgnoreCase), "$1en"),
        (new Regex(@"(m|l)ice$", RegexOptions.IgnoreCase), "$1ice"),
        (new Regex(@"(m|l)ouse$", RegexOptions.IgnoreCase), "$1ice"),
        (new Regex(@"(passer)s?by$", RegexOptions.IgnoreCase), "$1sby"),
        (new Regex(@"(matr|vert|append)ix|ex$", RegexOptions.IgnoreCase), "$1ices"),
        (new Regex(@"(x|ch|ss|sh)$", RegexOptions.IgnoreCase), "$1es"),
        (new Regex(@"([^aeiouy]}|qu)y$", RegexOptions.IgnoreCase), "$1ies"),
        (new Regex(@"(hive)$", RegexOptions.IgnoreCase), "$1s"),
        (new Regex(@"([^f])fe$", RegexOptions.IgnoreCase), "$1ves"),
        (new Regex(@"(ar|l|ea|eo|oa|hoo)f$", RegexOptions.IgnoreCase), "$1ves"),
        (new Regex(@"sis$", RegexOptions.IgnoreCase), "ses"),
        (new Regex(@"([ti])a$", RegexOptions.IgnoreCase), "$1a"),
        (new Regex(@"([ti])um$", RegexOptions.IgnoreCase), "$1a"),
        (new Regex(@"(buffal|tomat|volcan|her|potat|ech|embar|torpedl)o$", RegexOptions.IgnoreCase), "$1oes"),
        (new Regex(@"(bu|mis|gas)s$", RegexOptions.IgnoreCase), "$1ses"),
        (new Regex(@"(alias|status)$", RegexOptions.IgnoreCase), "$1es"),
        (new Regex(@"(octop|vir|radi|nucle|fung|cact|stimul)us$", RegexOptions.IgnoreCase), "$1i"),
        (new Regex(@"(octop|vir|radi|nucle|fung|cact|stimul)i$", RegexOptions.IgnoreCase), "$1i"),
        (new Regex(@"(ax|test)is$", RegexOptions.IgnoreCase), "$1es"),
        (new Regex(@"s$", RegexOptions.IgnoreCase), "s"),
        (new Regex(@"$", RegexOptions.None), "s")
    ];

    private static readonly List<(Regex Pattern, string Replacement)> SingularRules =
    [
        (new Regex(@"(database)s$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(quiz)zes$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(matr|vert|append)ices$", RegexOptions.IgnoreCase), "$1ix"),
        (new Regex(@"^(ox)en", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(alias|status)es$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(octop|vir|radi|nucle|fung|cact|stimul)i$", RegexOptions.IgnoreCase), "$1us"),
        (new Regex(@"(cris|ax|test)es$", RegexOptions.IgnoreCase), "$1is"),
        (new Regex(@"(shoe)s$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(o)es$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(bus)ses$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(m|l)ice$", RegexOptions.IgnoreCase), "$1ouse"),
        (new Regex(@"(x|ch|ss|sh)es$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(m)ovies$", RegexOptions.IgnoreCase), "$1ovie"),
        (new Regex(@"(s)eries$", RegexOptions.IgnoreCase), "$1eries"),
        (new Regex(@"([^aeiouy]|qu)ies$", RegexOptions.IgnoreCase), "$1y"),
        (new Regex(@"([lr])ves$", RegexOptions.IgnoreCase), "$1f"),
        (new Regex(@"(tive)s$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"(hive)s$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"([^f])ves$", RegexOptions.IgnoreCase), "$1fe"),
        (new Regex(@"(t)he(sis|ses)$", RegexOptions.IgnoreCase), "$1hesis"),
        (new Regex(@"(synop|parenthe|diagno|ba|analy|hypothe|ellip|neurosi)ses$", RegexOptions.IgnoreCase), "$1sis"),
        (new Regex(@"([ti])a$", RegexOptions.IgnoreCase), "$1um"),
        (new Regex(@"(n)ews$", RegexOptions.IgnoreCase), "$1ews"),
        (new Regex(@"(ss)$", RegexOptions.IgnoreCase), "$1"),
        (new Regex(@"s$", RegexOptions.IgnoreCase), "")
    ];

    /// <summary>
    /// Applies plural rules to the given word, returning the first match.
    /// </summary>
    internal static string ApplyPluralRules(string word)
    {
        for (int i = 0; i < PluralRules.Count; i++)
        {
            var (pattern, replacement) = PluralRules[i];
            if (pattern.IsMatch(word))
            {
                return pattern.Replace(word, replacement);
            }
        }

        return word + "s";
    }

    /// <summary>
    /// Applies singular rules to the given word, returning the first match.
    /// </summary>
    internal static string ApplySingularRules(string word)
    {
        for (int i = 0; i < SingularRules.Count; i++)
        {
            var (pattern, replacement) = SingularRules[i];
            if (pattern.IsMatch(word))
            {
                return pattern.Replace(word, replacement);
            }
        }

        return word;
    }
}
