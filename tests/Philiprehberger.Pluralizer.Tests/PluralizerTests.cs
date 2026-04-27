using Xunit;

namespace Philiprehberger.Pluralizer.Tests;

public class PluralizerTests
{
    [Theory]
    [InlineData("cat", "cats")]
    [InlineData("bus", "buses")]
    [InlineData("box", "boxes")]
    [InlineData("baby", "babies")]
    [InlineData("person", "people")]
    [InlineData("child", "children")]
    [InlineData("knife", "knives")]
    [InlineData("sheep", "sheep")]
    [InlineData("information", "information")]
    public void Pluralize_ProducesExpectedForm(string singular, string expected)
    {
        Assert.Equal(expected, Pluralizer.Pluralize(singular));
    }

    [Theory]
    [InlineData("cats", "cat")]
    [InlineData("boxes", "box")]
    [InlineData("babies", "baby")]
    [InlineData("people", "person")]
    [InlineData("children", "child")]
    [InlineData("wolves", "wolf")]
    [InlineData("sheep", "sheep")]
    public void Singularize_ProducesExpectedForm(string plural, string expected)
    {
        Assert.Equal(expected, Pluralizer.Singularize(plural));
    }

    [Fact]
    public void Pluralize_PreservesCapitalization()
    {
        Assert.Equal("Cats", Pluralizer.Pluralize("Cat"));
        Assert.Equal("PEOPLE", Pluralizer.Pluralize("PERSON"));
    }

    [Theory]
    [InlineData(0, "item", "0 items")]
    [InlineData(1, "item", "1 item")]
    [InlineData(5, "item", "5 items")]
    [InlineData(1, "person", "1 person")]
    [InlineData(3, "person", "3 people")]
    public void Format_PicksCorrectForm(int count, string word, string expected)
    {
        Assert.Equal(expected, Pluralizer.Format(count, word));
    }

    [Fact]
    public void IsPlural_DetectsPlurals()
    {
        Assert.True(Pluralizer.IsPlural("cats"));
        Assert.True(Pluralizer.IsPlural("people"));
        Assert.True(Pluralizer.IsPlural("sheep")); // uncountable
        Assert.False(Pluralizer.IsPlural("cat"));
    }

    [Fact]
    public void IsSingular_DetectsSingulars()
    {
        Assert.True(Pluralizer.IsSingular("cat"));
        Assert.True(Pluralizer.IsSingular("person"));
        Assert.True(Pluralizer.IsSingular("sheep")); // uncountable
        Assert.False(Pluralizer.IsSingular("cats"));
    }

    [Fact]
    public void AddIrregular_RegistersCustomPair()
    {
        Pluralizer.AddIrregular("octocat", "octocats");

        Assert.Equal("octocats", Pluralizer.Pluralize("octocat"));
        Assert.Equal("octocat", Pluralizer.Singularize("octocats"));
    }

    [Fact]
    public void AddUncountable_TreatsWordAsInvariant()
    {
        Pluralizer.AddUncountable("software");

        Assert.Equal("software", Pluralizer.Pluralize("software"));
        Assert.Equal("software", Pluralizer.Singularize("software"));
    }

    [Theory]
    [InlineData(1, "1st")]
    [InlineData(2, "2nd")]
    [InlineData(3, "3rd")]
    [InlineData(4, "4th")]
    [InlineData(11, "11th")]
    [InlineData(12, "12th")]
    [InlineData(13, "13th")]
    [InlineData(21, "21st")]
    [InlineData(101, "101st")]
    [InlineData(113, "113th")]
    public void Ordinalize_ReturnsExpectedSuffix(int number, string expected)
    {
        Assert.Equal(expected, Pluralizer.Ordinalize(number));
    }

    [Theory]
    [InlineData("the quick brown fox", "The Quick Brown Fox")]
    [InlineData("a tale of two cities", "A Tale of Two Cities")]
    [InlineData("hello", "Hello")]
    public void Titleize_CapitalizesMajorWords(string input, string expected)
    {
        Assert.Equal(expected, Pluralizer.Titleize(input));
    }

    [Fact]
    public void Titleize_WithCount_PluralizesFinalNoun()
    {
        Assert.Equal("3 Open Bugs", Pluralizer.Titleize(3, "open bug"));
        Assert.Equal("1 Open Bug", Pluralizer.Titleize(1, "open bug"));
    }

    [Theory]
    [InlineData(1, "first")]
    [InlineData(2, "second")]
    [InlineData(11, "eleventh")]
    [InlineData(20, "twentieth")]
    [InlineData(23, "twenty-third")]
    [InlineData(100, "one hundredth")]
    [InlineData(123, "one hundred twenty-third")]
    public void ToOrdinalWords_ReturnsExpectedWording(int number, string expected)
    {
        Assert.Equal(expected, Pluralizer.ToOrdinalWords(number));
    }

    [Fact]
    public void ToOrdinalWords_OutOfRange_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Pluralizer.ToOrdinalWords(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => Pluralizer.ToOrdinalWords(1000));
    }

    [Fact]
    public void Pluralize_NullThrows()
    {
        Assert.Throws<ArgumentNullException>(() => Pluralizer.Pluralize(null!));
    }
}
