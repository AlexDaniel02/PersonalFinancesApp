# PersonalFinancesApp


## Description
The Personal Finances App is a .NET application that helps users manage their personal finances.
It provides features such as expense tracking, budget management, and financial goal setting.

## Prerequisites
Before running the Personal Finances App, make sure you have the following software installed on your machine:

- [Visual Studio](https://visualstudio.microsoft.com/downloads/): Integrated development environment for .NET development.
- [PostgreSQL](https://www.postgresql.org/download/): Open-source relational database management system.

## Installation
To run the Personal Finances App locally, follow these steps:

1. Clone the repository
2. Set up the database:
- Create a new PostgreSQL database for the application.
- Open the `appsettings.json` file in the `PersonalFinancesApp` project.
- Locate the `PersonalFinancesDbContext.cs` file within the `Models` folder.
- In the `OnConfiguring` method, update the connection string to match your PostgreSQL connection details (e.g., server, database, username, password).
- 
3. Open the solution in Visual Studio:
- Launch Visual Studio.
- Click on **File** > **Open** > **Project/Solution**.
- Navigate to the cloned repository and select the `.sln` file.

4. Build and run the application:

## Technologies Used
The Personal Finances App is built using the following technologies:

- .NET 6.0: A free, open-source, cross-platform framework for building modern applications using C#.
- Entity Framework Core: An object-relational mapping (ORM) framework for .NET that simplifies database access and management.
- PostgreSQL: An open-source relational database management system that provides data persistence for the application.
