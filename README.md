# CourseApiV2
Educational purpose - This is an API connected to a SQLite database file. The purpose is to teach how to use proper HTML status codes, and distinguish between when using a DTO, ViewModel or Entity.

## How to use

* In the root of the project, run 'dotnet restore' from the command line, to retrieve all the missing dependencies.
* Go to the web application folder /CourseApiV2 and run 'dotnet run'
* Now the api is running on http://localhost:5000, and the root of the api is at location http://localhost:5000/api/v1/courses

## Available methods

* http://localhost:5000/api/v1/courses (GET) -> Fetches all the courses on the latest semester
* http://localhost:5000/api/v1/courses?semester=20152 (GET) -> Same method, but instead uses a filter for which semester it wants to filter by
* http://localhost:5000/api/v1/courses/{id:int} (GET) -> Gets a specific course with more detailed information
* http://localhost:5000/api/v1/courses/{id:int} (PUT) -> Updates a course with the given id, the new fields must be in HTTP body
* http://localhost:5000/api/v1/courses/{id:int} (DELETE) -> Deletes the course with the given id
* http://localhost:5000/api/v1/courses/{id:int}/students (GET) -> Gets all students registered in the given course
* http://localhost:5000/api/v1/courses/{id:int}/students (POST) -> Adds a new student to the given course

## Documentation

When the API is running on localhost:5000, you can access the documentation of the API at http://localhost:5000/docs
