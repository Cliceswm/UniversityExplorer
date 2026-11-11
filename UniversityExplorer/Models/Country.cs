namespace UniversityExplorer.Models;

// Represents ONE country returned by the Countries API
// (https://countries.dev/countries).
// The property names match the JSON field names, so .NET
// fills them in automatically when the data arrives.
public class Country
{
    // Country name, e.g. "Ireland"
    public string Name { get; set; } = "";

    // Capital city, e.g. "Dublin".
    // The "?" means it can be empty (null), because a few countries have no capital.
    public string? Capital { get; set; }

    // Region, e.g. "Europe"
    public string Region { get; set; } = "";

    // Smaller region, e.g. "Northern Europe" (can be empty)
    public string? Subregion { get; set; }

    // Number of people. "long" is used because some populations are very large.
    public long Population { get; set; }

    // Flag as an emoji, e.g. 🇮🇪
    public string Flag { get; set; } = "";

    // Flag as an image link (works on all computers, unlike emoji)
    public CountryFlags? Flags { get; set; }

    // Two-letter country code, e.g. "IE"
    public string Alpha2Code { get; set; } = "";
}

// The API sends the flag images inside a small object:
// "flags": { "png": "...", "svg": "..." }
// so we need a small class to hold them.
public class CountryFlags
{
    public string Png { get; set; } = "";
    public string Svg { get; set; } = "";
}