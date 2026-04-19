Movie List - Exercise 4-1

What is in here:
- Movie model
- Genre model
- MovieContext
- Home controller and Movie controller
- Edit and Delete views
- bootstrap layout
- connection string set to MoviesExercise

Notes:
- if you are starting fresh, open Package Manager Console and run:
  Add-Migration Initial
  Update-Database

- if you are doing the genre part after that, run:
  Add-Migration Genre
  Update-Database

- the starter I used already had the movie list setup, so I changed the files to match the exercise parts and the db name for this project
- if you get the .NET message, check the csproj and make sure it says net8.0
- if the database will not open, make sure localdb is installed
