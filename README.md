# DB setup
- Install PostgreSQL package in Nuget
- Set up appsettings.json with your PostgreSQL connection string
	- if you forgot postgress password, run:
		- ALTER USER postgres WITH PASSWORD 'password';
- Run the following commands in the Package Manager Console:
  - dotnet ef migrations add InitialCreate
  - Update-Database