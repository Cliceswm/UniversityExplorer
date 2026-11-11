using System.Text.Json.Serialization;

namespace UniversityExplorer.Models;

// Represents ONE university returned by the Universities API
// (http://universities.hipolabs.com/search?country=Ireland).
public class University
{
    // [JsonPropertyName("...")] tells .NET which JSON field
    // goes into which property. We need it here because some JSON
    // names use underscores or dashes, which C# doesn't allow.

    // University name, e.g. "Trinity College Dublin"
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    // Country name, e.g. "Ireland"
    [JsonPropertyName("country")]
    public string Country { get; set; } = "";

    // Two-letter country code, e.g. "IE"
    [JsonPropertyName("alpha_two_code")]
    public string AlphaTwoCode { get; set; } = "";

    // List of websites (the API sends a list, usually with just one item)
    [JsonPropertyName("web_pages")]
    public List<string> WebPages { get; set; } = new();

    // List of domains, e.g. "tcd.ie"
    [JsonPropertyName("domains")]
    public List<string> Domains { get; set; } = new();

    // State or province (often empty)
    [JsonPropertyName("state-province")]
    public string? StateProvince { get; set; }

    // ---- Helper properties (NOT from the API) ----
    // [JsonIgnore] means "this isn't in the JSON, don't look for it".

    // The first website in the list, or "" if there isn't one
    [JsonIgnore]
    public string Website => WebPages.FirstOrDefault() ?? "";

    // The first domain in the list, or "" if there isn't one
    [JsonIgnore]
    public string Domain => Domains.FirstOrDefault() ?? "";
}