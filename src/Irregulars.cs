namespace Philiprehberger.Pluralizer;

/// <summary>
/// Contains a dictionary of irregular English word forms that do not follow standard pluralization rules.
/// </summary>
internal static class Irregulars
{
    private static readonly Dictionary<string, string> SingularToPlural = new(StringComparer.OrdinalIgnoreCase)
    {
        ["person"] = "people",
        ["man"] = "men",
        ["woman"] = "women",
        ["child"] = "children",
        ["mouse"] = "mice",
        ["goose"] = "geese",
        ["tooth"] = "teeth",
        ["foot"] = "feet",
        ["ox"] = "oxen",
        ["leaf"] = "leaves",
        ["life"] = "lives",
        ["knife"] = "knives",
        ["wife"] = "wives",
        ["half"] = "halves",
        ["elf"] = "elves",
        ["loaf"] = "loaves",
        ["potato"] = "potatoes",
        ["tomato"] = "tomatoes",
        ["cactus"] = "cacti",
        ["focus"] = "foci",
        ["fungus"] = "fungi",
        ["nucleus"] = "nuclei",
        ["syllabus"] = "syllabi",
        ["analysis"] = "analyses",
        ["diagnosis"] = "diagnoses",
        ["thesis"] = "theses",
        ["crisis"] = "crises",
        ["phenomenon"] = "phenomena",
        ["criterion"] = "criteria",
        ["datum"] = "data",
        ["medium"] = "media",
        ["memorandum"] = "memoranda",
        ["curriculum"] = "curricula",
        ["index"] = "indices",
        ["appendix"] = "appendices",
        ["matrix"] = "matrices",
        ["vertex"] = "vertices",
        ["stimulus"] = "stimuli",
        ["antenna"] = "antennae",
        ["formula"] = "formulae",
        ["nebula"] = "nebulae",
        ["vertebra"] = "vertebrae",
        ["louse"] = "lice",
        ["die"] = "dice",
        ["quiz"] = "quizzes",
        ["move"] = "moves",
        ["sex"] = "sexes"
    };

    private static readonly Dictionary<string, string> PluralToSingular;

    static Irregulars()
    {
        PluralToSingular = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var (singular, plural) in SingularToPlural)
        {
            PluralToSingular[plural] = singular;
        }
    }

    /// <summary>
    /// Attempts to find the plural form of an irregular singular word.
    /// </summary>
    internal static bool TryGetPlural(string singular, out string plural)
    {
        return SingularToPlural.TryGetValue(singular, out plural!);
    }

    /// <summary>
    /// Attempts to find the singular form of an irregular plural word.
    /// </summary>
    internal static bool TryGetSingular(string plural, out string singular)
    {
        return PluralToSingular.TryGetValue(plural, out singular!);
    }

    /// <summary>
    /// Adds a custom irregular word pair.
    /// </summary>
    internal static void Add(string singular, string plural)
    {
        SingularToPlural[singular] = plural;
        PluralToSingular[plural] = singular;
    }
}
