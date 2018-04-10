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