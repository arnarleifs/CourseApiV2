# CourseApiV2
Educational purpose - This is an API connected to a SQLite database file. The purpose is to teach how to use proper HTML status codes, and distinguish between when using a DTO, ViewModel or Entity.

## How to use

* In the root of the project, run 'dotnet restore' from the command line, to retrieve all the missing dependencies.
* Go to the web application folder /CourseApiV2 and run 'dotnet run'
* Now the api is running on http://localhost:5000, and the root of the api is at location http://localhost:5000/api/v1/courses

## Available methods

* http://localhost:5000/api/v1/courses (GET) -> Fetches all the courses on the latest semester
* http://localhost:5000/api/v1/courses?semester=20152 (GET) -> Same method, but instead uses a filter for which semester it wants to filter by
