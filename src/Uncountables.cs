namespace Philiprehberger.Pluralizer;

/// <summary>
/// Contains a set of uncountable English words that have the same form in both singular and plural.
/// </summary>
internal static class Uncountables
{
    private static readonly HashSet<string> Words = new(StringComparer.OrdinalIgnoreCase)
    {
        "equipment",
        "information",
        "rice",
        "money",
        "species",
        "series",
        "fish",
        "sheep",
        "deer",
        "aircraft",
        "bison",
        "buffalo",
        "cattle",
        "cod",
        "elk",
        "grouse",
        "homework",
        "luggage",
        "moose",
        "mud",
        "news",
        "offspring",
        "plankton",
        "police",
        "salmon",
        "shrimp",
        "spacecraft",
        "squid",
        "swine",
        "trout",
        "tuna",
        "wheat",
        "wood",
        "wool",
        "feedback",
        "furniture",
        "garbage",
        "graffiti",
        "jewelry",
        "knowledge",
        "leisure",
        "machinery",
        "mathematics",
        "music",
        "nutrition",
        "offspring",
        "physics",
        "poetry",
        "pollution",
        "research",
        "scenery",
        "software",
        "traffic",
        "understanding",
        "weather",
        "wilderness"
    };

    /// <summary>
    /// Determines whether the specified word is uncountable.
    /// </summary>
    internal static bool IsUncountable(string word)
    {
        return Words.Contains(word);
    }

    /// <summary>
    /// Adds a word to the uncountable set.
    /// </summary>
    internal static void Add(string word)
    {
        Words.Add(word);
    }
}
