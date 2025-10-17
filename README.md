# DB setup
- Install PostgreSQL package in Nuget
- Set up appsettings.json with your PostgreSQL connection string
	- if you forgot postgress password, run:
		- ALTER USER postgres WITH PASSWORD 'password';
- Run the following commands in the Package Manager Console:
  - dotnet ef migrations add InitialCreate
  - dotnet ef database update
- The tables will now exist in your database
	- if you get an error about Microsoft.EntityFrameworkCore.Design, install the package in Nuget, and rebuild the project
- to insert into Postgres, it doesn't like capitalized names:
	- insert into "ItemCategories"("Name") values('Helmet')


# Digital Ocean setup
- create a basic droplet with Ubuntu
- ssh into the droplet
	- ssh root@your_droplet_ip
	- enter password
- install .NET SDK on the droplet
	- follow instructions here: https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu
	- check installation with:
		- dotnet --version
- install git on the droplet
	- sudo apt-get install git
	- check installation with:
		- git --version
- clone your repository
	- git clone your_repo_url
- build your project
	- cd your_project_folder
	- dotnet build
- install postgresql on the droplet
	- sudo apt-get install postgresql
	- switch to the postgres user
		- sudo su postgres
	- enter the psql shell
		- psql
		- list tables
			- \l
- set environment variables for your connection string
	- export ConnectionStrings__MarketContext="Host=localhost;Database=AbiMarket;Username=postgres;Password=password"
	- check that it worked with:
		- printenv | grep ConnectionStrings
- i then realized this was a massive pain and decided to host on Azure instead


# Azure setup
- create an Azure account if you don't have one
- following these guides to set up a web app with a PostgreSQL database:
	- https://learn.microsoft.com/en-us/visualstudio/azure/end-to-end-deployment-entity-framework-core-github-actions?view=vs-2022#create-the-azure-sql-database
	- https://github.com/Azure-Samples/app-templates-dotnet-azuresql-appservice