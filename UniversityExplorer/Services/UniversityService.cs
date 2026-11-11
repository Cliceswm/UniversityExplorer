using System.Net.Http.Json;
using UniversityExplorer.Models;

namespace UniversityExplorer.Services;

// Talks to the Universities API.
public class UniversityService(HttpClient http)
{
    // PROBLEM: the two APIs don't always use the same country names.
    // The Countries API says "United Kingdom of Great Britain and Northern Ireland",
    // but the Universities API only understands "United Kingdom".
    // This dictionary translates the names: Countries API name → Universities API name.
    // (This is a good thing to mention in your README: it's part of the "mashup".)
    private static readonly Dictionary<string, string> NameMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["United Kingdom of Great Britain and Northern Ireland"] = "United Kingdom",
        ["United States of America"] = "United States",
        ["Korea (Republic of)"] = "Korea, Republic of",
        ["Vietnam"] = "Viet Nam",
    };

    // Gets all universities for one country, sorted A–Z.
    public async Task<List<University>> GetByCountryAsync(string country)
    {
        // 1. If the name is in our dictionary, use the translated version
        var name = NameMap.TryGetValue(country, out var mapped) ? mapped : country;

        // 2. Ask the API
        var results = await FetchAsync(name);

        // 3. Nothing found, and the name has brackets?
        //    e.g. "Iran (Islamic Republic of)" → try again with just "Iran"
        if (results.Count == 0 && name.Contains('('))
        {
            var shortName = name[..name.IndexOf('(')].Trim();
            results = await FetchAsync(shortName);
        }

        return results.OrderBy(u => u.Name).ToList();
    }

    // Private helper: does the actual web request.
    // Uri.EscapeDataString makes the name safe for a URL (spaces become %20 etc.)
    private async Task<List<University>> FetchAsync(string country)
    {
        var url = $"http://universities.hipolabs.com/search?country={Uri.EscapeDataString(country)}";
        return await http.GetFromJsonAsync<List<University>>(url) ?? new();
    }
}