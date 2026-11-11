using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityExplorer.Models;

// Represents ONE student application from the Edutots API
// (https://edutots.net/api/studentapplication).
// We use this class for GET (reading), POST (creating) and PUT (updating).
//
// The [Required], [EmailAddress] etc. lines are "Data Annotations".
// They are VALIDATION RULES: the form will refuse to submit
// and show the ErrorMessage if a rule is broken.
public class StudentApplication
{
    // Unique number the API gives each application (we don't type this in)
    public int Id { get; set; }

    // Must be filled in, and between 2 and 100 characters
    [Required(ErrorMessage = "Student name is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be 2–100 characters.")]
    public string StudentName { get; set; } = "";

    // Must be filled in AND look like a real email (has @ etc.)
    // Note: the brief says [Email] but that doesn't exist in .NET.
    // The correct attribute is [EmailAddress].
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Country is required.")]
    public string Country { get; set; } = "";

    // The API calls this field "university", but we want a clearer
    // name in our code, so we map it with JsonPropertyName.
    [Required(ErrorMessage = "University name is required.")]
    [JsonPropertyName("university")]
    public string UniversityName { get; set; } = "";

    // Same idea: the API calls it "course"
    [Required(ErrorMessage = "Course name is required.")]
    [JsonPropertyName("course")]
    public string CourseName { get; set; } = "";

    // Optional text, max 1000 characters
    [StringLength(1000, ErrorMessage = "Max 1000 characters.")]
    public string? PersonalStatement { get; set; }

    // The brief requires an application date, but the API doesn't
    // currently return one. It's nullable (DateTime?) so old records
    // show nothing instead of a weird date like 01/01/0001.
    // New applications default to today's date.
    [Required(ErrorMessage = "Application date is required.")]
    public DateTime? ApplicationDate { get; set; } = DateTime.Today;
}