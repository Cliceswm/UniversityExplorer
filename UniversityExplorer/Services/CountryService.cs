using System.Net.Http.Json;
using UniversityExplorer.Models;

namespace UniversityExplorer.Services;

// Talks to the Countries API.
//
// "(HttpClient http)" after the class name is a "primary constructor".
// Blazor automatically gives us an HttpClient (the object that sends
// web requests) when it creates this service. We set that up in Program.cs.
public class CountryService(HttpClient http)
{
    // Gets ALL countries, sorted A–Z by name.
    // "async Task" means this method waits for the internet without
    // freezing the app. You call it with "await".
    public async Task<List<Country>> GetAllAsync()
    {
        // GetFromJsonAsync = send a GET request, then turn the JSON into a List<Country>
        var countries = await http.GetFromJsonAsync<List<Country>>("https://countries.dev/countries");

        // "?? new()" means: if the result is null, use an empty list instead
        countries ??= new();

        // Sort alphabetically so the dropdown is easy to use
        return countries.OrderBy(c => c.Name).ToList();
    }
}