# MinimalApi
Simple practice of the dotnet 6 minimal API feature.

## Commands I used:
 - For creating the project using the minimal API template: `dotnet new webapi -minimal -o MinimalApi.Api`
 - To add new migration: `dotnet ef dotnet ef migrations add "Migration_name" --project .\src\MinimalApi.Api\ --output-dir Persistence\Migrations`
 - To update the database: `dotnet ef database update --project .\src\MinimalApi.Api\`