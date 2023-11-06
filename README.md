1. Install Duende.IdentityServer.Templates using ```dotnet new -i Duende.IdentityServer.Templates``` in command prompt
1. Create new dotnet project using ```Duende IdentityServer with Entity Framework Stores``` template
1. Install ```Microsoft.EntityFrameworkCore.SqlServer``` and ```Microsoft.EntityFrameworkCore.Tools``` in NuGet Package Manager
1. In ```appsettings.json```, add ```"db": "Server={db server};Database={db name};User ID={username};Password={password};trusted_connection=yes;TrustServerCertificate=true;"``` under ```ConnectionStrings```
1. In ```HostingExtensions.cs```, change line 18 to say ```var connectionString = builder.Configuration.GetConnectionString("db");```
1. In the same file, add change lines 36 and 46 to say ```b.UseSqlServer(connectionString);```