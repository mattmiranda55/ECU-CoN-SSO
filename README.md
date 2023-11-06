1. Open Microsoft SQL Server Management Studio and create a new database named "IdentityServer"
2. Create a new login with a username and password that you chose. Make sure to click ```SQL Sever Authentication```and unclick ```Enforce Password Policy```
1. Install Duende.IdentityServer.Templates using ```dotnet new -i Duende.IdentityServer.Templates``` in command prompt
1. Open the .sln file in Visual Studio
1. Install ```Microsoft.EntityFrameworkCore.SqlServer```, ```Microsoft.EntityFrameworkCore.Tools```, ```Microsoft.EntityFrameworkCore.Design``` in NuGet Package Manager
2. In ```appsettings.json``` change the ConnectionString "db" to ```"db": "Server={server name};Database=IdentityServer;User ID={username of login};Password={password};trusted_connection=yes;TrustServerCertificate=true;"```
1. Run ```.\buildschema``` in the Visual Studio Developer PowerShell window
1. Run ```Update-Database -Context PersistedGrantDbContext``` and ```Update-Database -Context ConfigurationDbContext``` in the NuGet Package Manager Console
