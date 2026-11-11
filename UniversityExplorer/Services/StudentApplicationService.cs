using System.Net;
using System.Net.Http.Json;
using UniversityExplorer.Models;

namespace UniversityExplorer.Services;

// Talks to the Edutots Student Application API.
// This is where GET, POST and PUT happen (worth 20 marks).
public class StudentApplicationService(HttpClient http)
{
    // The base address, written once so we don't repeat it everywhere
    private const string BaseUrl = "https://edutots.net/api/studentapplication";

    // GET: all applications (used by the Student Applications page)
    public async Task<List<StudentApplication>> GetAllAsync()
    {
        return await http.GetFromJsonAsync<List<StudentApplication>>(BaseUrl) ?? new();
    }

    // GET: one application by its Id (used by the Edit page to fill the form)
    public async Task<StudentApplication?> GetByIdAsync(int id)
    {
        try
        {
            // Try GET https://edutots.net/api/studentapplication/5
            return await http.GetFromJsonAsync<StudentApplication>($"{BaseUrl}/{id}");
        }
        catch (HttpRequestException ex)
            when (ex.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.MethodNotAllowed)
        {
            // If the API doesn't support getting one item,
            // get ALL of them and pick the one with the matching Id.
            var all = await GetAllAsync();
            return all.FirstOrDefault(a => a.Id == id);
        }
    }

    // POST: create a new application (used by the Create page)
    public async Task CreateAsync(StudentApplication application)
    {
        // PostAsJsonAsync turns our object into JSON and sends it
        var response = await http.PostAsJsonAsync(BaseUrl, application);

        // If the API replied with an error (e.g. 400 or 500), throw an exception.
        // The page will catch it and show an error message to the user.
        response.EnsureSuccessStatusCode();
    }

    // PUT: update an existing application (used by the Edit page)
    public async Task UpdateAsync(int id, StudentApplication application)
    {
        // PUT https://edutots.net/api/studentapplication/5
        var response = await http.PutAsJsonAsync($"{BaseUrl}/{id}", application);
        response.EnsureSuccessStatusCode();
    }
}