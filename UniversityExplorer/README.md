# University Explorer Portal

CA2 - Full Stack Development
Student: Watson Melo - 75428

## About the project

This is a Blazor Web App made with .NET 10 and C#. It lets the user explore universities from different countries and manage student applications.

The project is an API mashup, which means it uses data from more than one API on the same page. When the user picks a country, the app shows the country details from the Countries API and then uses the country name to get the universities from the Universities API.

The app also connects to the Edutots Student Application API to view, create, edit and delete applications.

## APIs used

- Countries API: https://countries.dev/countries
- Universities API: http://universities.hipolabs.com/search?country={country}
- Student Application API: https://edutots.net/api/studentapplication
  - GET to show all applications
  - POST to create an application
  - PUT to edit an application
  - DELETE to delete an application

## Features

- Select a country from a dropdown
- See the country details (name, capital, region, population and flag)
- See the list of universities for that country
- Search universities by name (it updates while typing)
- Click a university to see more details (name, country, website and domain)
- Apply button that opens the form with the country and university already filled in
- See all student applications
- Create a new application
- Edit an application
- Validation on the form using Data Annotations
- Loading messages while the data is loading
- Error messages if an API doesn't work

### Extra features

- Delete an application (with a pop-up to confirm first)
- Sort universities A-Z or Z-A
- Responsive design with Bootstrap

## Pages

- Home - `/`
- University Explorer - `/university-explorer`
- Student Applications - `/student-applications`
- Create Student Application - `/student-applications/create`
- Edit Application - `/student-applications/edit/{id}`

## Project structure

- **Models** - Country, University and StudentApplication classes. They match the JSON from the APIs.
- **Services** - CountryService, UniversityService and StudentApplicationService. These are the classes that call the APIs using HttpClient.
- **Components/Shared** - the reusable components:
  - CountrySelector - the country dropdown
  - CountryDetails - shows the country info
  - UniversityCard - shows a university in the list
  - UniversityDetails - shows the details of the selected university
  - StudentApplicationForm - the form used in both Create and Edit pages
  - StudentApplicationRow - one row of the applications table with Edit and Delete buttons
- **Components/Pages** - the pages of the app

## EventCallback

I used EventCallback so the components can send information back to the page:

- CountrySelector uses `OnCountrySelected` when a country is picked
- UniversityCard uses `OnSelect` when a university is clicked
- UniversityDetails uses `OnClose` and `OnApply`
- StudentApplicationForm uses `OnValidSubmit` when the form is valid
- StudentApplicationRow uses `OnEdit` and `OnDelete`

## Problems I had

- Some country names are different in the two APIs. For example the Countries API says "United Kingdom of Great Britain and Northern Ireland" but the Universities API only works with "United Kingdom". I fixed this with a small dictionary in UniversityService that changes the name before calling the API.
- The Edutots API uses `university` and `course` instead of `universityName` and `courseName`, so I used `[JsonPropertyName]` in the model.
- The Edutots API doesn't return an application date, so the list shows today's date by default for applications that don't have one.
- I called the explorer page file `UniversityExplorerPage.razor` because `UniversityExplorer` is already the name of the project and it caused errors. The route is still `/university-explorer`.
- I used Interactive Server mode because the Universities API uses http and not https, so calling it from the browser could get blocked.

## How to run

1. Clone the repository
2. Open `UniversityExplorer.sln` in Visual Studio
3. Press F5 to run

## Screenshots

### 1. Home Page
![Home Page](screenshots/01-home.png)

### 2. University Explorer Page
![University Explorer](screenshots/02-explorer.png)

### 3. Country selected and details displayed
![Country Details](screenshots/03-country-details.png)

### 4. Universities loaded for a selected country
![Universities](screenshots/04-universities.png)

### 5. University search
![Search](screenshots/05-search.png)

### 6. University details displayed
![University Details](screenshots/06-university-details.png)

### 7. Student Applications page (GET)
![Student Applications](screenshots/07-applications.png)

### 8. Create Student Application page (POST)
![Create Application](screenshots/08-create.png)

### 9. Edit Student Application page (PUT)
![Edit Application](screenshots/09-edit.png)

### 10. Loading state
![Loading State](screenshots/10-loading.png)

### 11. Error handling state
![Error State](screenshots/11-error.png)

### 12. Delete application (extra)
![Delete](screenshots/12-delete.png)

### 13. Sorting universities (extra)
![Sorting](screenshots/13-sorting.png)