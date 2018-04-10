## Transport Me
.NET Core 2.0 based Web API which gives transport information in major cities. For example, tube information in London, city details and major tourist destination and how to transport. 

## Using EF Core with ASP.Net Core 2.0 for SQL Server Provider
- The Nuget packages required: 
    - Microsoft.EntityFrameworkCore.SqlServer (SQL Server database provider for Entity Framework Core)
    - Microsoft.EntityFrameworkCore.Tools (Includes Scaffold-DbContext, Add-Migration, and Update-Database.)

### Adding Migrations
- In the database (or Infrastructure) project associated with EF, run the command in Package Manager Console:  
```
PM > Add-Migration InitialCreate
```
- The above command will create a *Migrations folder* with a snapshot file which contains the current model expressed in POCO class, and *date-time stamped migration file* which has methods to update to new version - **up method**, and downgrade **down method**
- Migrations can also be created using the dotnet ef tooling `dotnet ef migrations add InitialCreate`
- References: Here is good guide to [starting with EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro)
- To update the database run the command in PM console `Update-Database`  
This can also be done in the code using `Database.Migrate()` in the constructor of the `DatabaseContext` class.   
- Make sure the tooling to run the command have enough *privilege* to create the *.mdf files
- `dotnet ef` tooling can also be used if we have the *package* - `Microsoft.EntityFrameworkCore.Tools.DotNet`.  
Make sure that the reference is in the *.csproj file.  
`<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0-preview1-final" />`
- To update the database, instead of `Update-Database`, the dotnet ef tooling command can be used `dotnet ef database update`
- Reference for [tooling and add-migration](https://github.com/aspnet/EntityFrameworkCore/issues/8996)
- Reference for [Update-Database CREATE File issue](https://github.com/aspnet/EntityFramework6/issues/384)

### Connection string and sensitive information in Environment Variables
- We can make use of the `ENVIRONMENT VARIABLES` in project properties to keep sensitive information from being add to version control system. These variables, would be saved in `launchSettings.json` though. 
```
"TransportMe.API": {
    "commandName": "Project",
    "launchBrowser": true,
    "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "ASPNETCORE_URLS": "https://localhost:5001;http://localhost:5000"
    }
}
```
- We can remove those, and put them in `System environment variables` to make sure that it is bound to the machine, and not the application. 
- Use `appsettings.json` for non-sensitive data, use `environment variables` for sensitive information. 
- [Connection string in Azure](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-dotnetcore-sqldb#configure-an-environment-variable)

### Seeding data
- There is a [PR](https://github.com/aspnet/EntityFrameworkCore/issues/629) for seeding data issue with EF Core (It might be available in 2.1 version). Update [here](https://github.com/aspnet/EntityFrameworkCore/pull/9996)
- We can use an extension method to write the seed information and then call this method when we configure the request-response pipeline in `Configure` method as explained [here](https://www.learnentityframeworkcore.com/migrations/seeding)
- [Seed data sample and issue](https://github.com/aspnet/EntityFrameworkCore/issues/11114)
- Update as of now - Seeding data in `OnModelCreating(ModelBuilder modelBuilder)`
```
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<City>().ToTable("City");
    modelBuilder.Entity<TransportMode>().ToTable("TransportMode");
    modelBuilder.Entity<TransportService>().ToTable("TransportService");

    // Seed data
    var londonCity = new City() { Id = 1, Name = "London", Country = "England" };
    modelBuilder.Entity<City>().SeedData(
        londonCity,
        new City() { Id = 2, Name = "Tokyo", Country = "Japan" }
        );
...
```

## References
- [Bind SSL Certificate, Azure](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-custom-ssl)