# # University Explorer Portal

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
<img width="1900" height="853" alt="image" src="https://github.com/user-attachments/assets/608c2586-1f39-427e-9159-5d24b121ee77" />


### 2. University Explorer Page
<img width="1568" height="752" alt="image" src="https://github.com/user-attachments/assets/9c864041-c0e4-4511-9e4a-179b4e785518" />


### 3. Country selected and details displayed
<img width="1514" height="784" alt="image" src="https://github.com/user-attachments/assets/41ccbb3c-9ba2-4bfb-a8ab-f71ab697915e" />

### 4. Universities loaded for a selected country
<img width="1512" height="790" alt="image" src="https://github.com/user-attachments/assets/c574c0a1-6b22-4086-9861-61d062559f47" />

### 5. University search
<img width="1512" height="790" alt="image" src="https://github.com/user-attachments/assets/7efd6bf7-4163-4f45-88d0-63889cf8988f" />

### 6. University details displayed
<img width="1652" height="858" alt="image" src="https://github.com/user-attachments/assets/1f260645-2d2b-47ef-9309-9507b4f31af5" />

### 7. Student Applications page (GET)
<img width="1888" height="902" alt="image" src="https://github.com/user-attachments/assets/06b09a06-5ee7-44fd-b235-477011b52a32" />

### 8. Create Student Application page (POST)
<img width="1665" height="857" alt="image" src="https://github.com/user-attachments/assets/f1ef5929-068d-4c16-b360-3ca2dd8171ed" />

### 9. Edit Student Application page (PUT)
<img width="1675" height="862" alt="image" src="https://github.com/user-attachments/assets/6c1259c5-ec24-453c-b8fb-89fb786284dd" />

### 10. Loading state
<img width="1907" height="912" alt="image" src="https://github.com/user-attachments/assets/ebd291a7-c8ac-4d12-9d4e-146a53dd9a1e" />

### 11. Delete application (extra)
<img width="1886" height="898" alt="image" src="https://github.com/user-attachments/assets/113624b6-58f2-4d02-b815-91c46196cc99" />
