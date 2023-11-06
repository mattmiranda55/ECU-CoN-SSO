1. Install Duende.IdentityServer.Templates using ```dotnet new -i Duende.IdentityServer.Templates``` in command prompt
1. Create new dotnet project using ```Duende IdentityServer with Entity Framework Stores``` template
1. Install ```Microsoft.EntityFrameworkCore.SqlServer```, ```Microsoft.EntityFrameworkCore.Tools```, ```Microsoft.EntityFrameworkCore.Design``` in NuGet Package Manager
1. Run ```.\buildschema``` in the Visual Studio Developer PowerShell window
1. Run ```Update-Database -Context PersistedGrantDbContext``` and ```Update-Database -Context ConfigurationDbContext``` in the NuGet Package Manager Console