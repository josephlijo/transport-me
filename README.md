# Transport Me
.NET Core 2.0 based Web API which gives transport information in major cities. For example, tube information in London, city details and major tourist destination and how to transport. 
The purpose of the application is to: 
- Explore ASP.NET Core Web API & Entity Framework Core (branch `webapi-basic`)
- Unit Testing, Integration Testing with Web API (branch `webapi-testing`)
- Docker with Windows (branch `webapi-docker`)
- Cloud integration with Azure (branch `webapi-cloud`)

## EF Core with ASP.NET MVC (Web API)
- We will see the usage of SQL Server Provider with EF Core
- The Nuget packages required are:  
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

### Using EF Core entities in Web API
- How can we access the database and provide it to the application?
    - ADO.NET
    - ORM like EF
- Then there are patterns to abstrat away the data access layer and business logic layer

### Without any patterns how do we access data?
- We use `DbContext` which is a session between the underlying database and the consumer and use this context to access the `DbSet`'s it holds
- EF already has POCO to represent the tables and abstracts away the `query` or `command` that we make. 

### Repository Pattern - Why?
- If we try to access the underlying database directly, it can result in:  
    - **Code duplication** and **violation of DRY** as we use *some common code* to access different table data which in a way we could abstract away and be avoided by using **generics** for example. 
    - **Testing issues** due to the repetition and tight coupling with a persistence medium which prevents us from isolating the SUT (Software Under Test) from the persistence (database)
    - **Tight coupling of a particular persistence medium** - For example, SQL Server, or MySQL database
- These issues can be solved by using [Repository pattern](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application#the-repository-and-unit-of-work-patterns)
    - Idea is to **create an abstraction layer between the data access layer and the business logic layer**
    - Doing so, we can insulate our application from changes in the underlying data store to an extent. 
    - This will make it easier to use automated unit testing or TDD (test-driven development)

### Is Repository Pattern Useful with EF or ORM?
- EF already abstracts aways the underlying details of how it communicates with the database
- Repositoy pattern is further abstraction on top of it (which is arguable on whether we need it or not) and hence it mostly resemble a `Facade pattern`
- It is useful, if we abstract away the underlying persistence medium from repository object so that we can switch the database and not useful if we violate that. 

### Lazy Loading, Eager Loading, and Explicit Loading
- **Eager Loading** is the process where a query for one *type of entity* also loads related entities as part of the query. It is achieved by the use of `Include` extension method.
- **Lazy Loading** is the process where the entity or collection of entities is loaded the first time a request is made to it. It is accomplished by decorating the property as `virtual`. EF will override this property to add a *loading hook* in the background. Lazy loading is the default behavior in EF. 
- **Explicity Loading** is the process of loading related entities explicitly - this is lazy loading when lazy loading is disabled. To do so, we use the `Reference` method with `Load`. For example, to load a blog related to a given post: `context.Entry(post).Reference(p => p.Blog).Load();`

### IEnumerable vs IQueryable in Repository pattern - better query expressions or violation of pattern
- IEnumerable used with EF works with data in-memory after the data set is pulled out from database
- IQueryable used with EF lets us add further query (order by, where) before the data is pulled out 
- IQueryable on contrast when used with EF also means that we are leaking persistence related logic out of the repository

### Using Auto-Mapper for converting database entities to View Model (or DTO's)
- Install the package `AutoMapper`
- Configure, for example:

## Help pages and documentation using Swagger (Open API)
- [Web API Help pages using Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.1)
- Using Swashbuckle: 
    - Install the package: `Install-Package Swashbuckle.AspNetCore`
    - Register it to service collection and include that in the request-response pipeline (`ConfigureServices`)

## References
- [Building Your First API with ASP.NET Core](https://app.pluralsight.com/library/courses/asp-dotnet-core-api-building-first) by Kevin Dockx
- [You're all doing Entity Framework wrong](https://medium.com/@hoagsie/youre-all-doing-entity-framework-wrong-ea0c40e20502)
- [Lazy loading, Eager Loading, Explicit Loading](https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx)
- [Bind SSL Certificate, Azure](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-custom-ssl)