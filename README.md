# EmpCompute

## Original Repo with dotnet 3.0 => https://github.com/EverestNwosu2/Paycompute

This is the project from udemy course (https://www.udemy.com/course/building-an-enterprise-application-with-aspnet-core-mvc/). 
The original one is developed in dotnet 3.0. I did a migration from **dotnet 3.0 to 6.0**.

# Tech Stack
- ASP.net MVC
- dotnet 6.0
- Entity Framework
- AspNetCore.Identity
- Razor pages
- Postgres

# Features
- MVC
- Emplpoyee CRUD
- Payment calculation CRUD
- User and Role Seeding (Admin,Manager,Staff)
- Authentication or Authorization

# How to Run
I use **visual studio code** for development.
- F5 for debug mode
- add migration => dotnet ef migrations add <migration_name> 
- updating database => dotnet ef database update
- chaning db connection => modify DefaultConnection in appsettings.json
