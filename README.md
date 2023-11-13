# How to Run Locally
1. Open Microsoft SQL Server Management Studio and create a new database named "IdentityServer"
2. Create a new login with a username and password that you chose. Make sure to click ```SQL Sever Authentication```and unclick ```Enforce Password Policy```
3. Map the login you created to the IdentityServer database and give the login the database roles of "public", "db_datareader", and "db_datawriter"
1. Install Duende.IdentityServer.Templates using ```dotnet new -i Duende.IdentityServer.Templates``` in command prompt
1. Open the .sln file in Visual Studio
1. Run ```dotnet restore``` in a command prompt window pointed at the root of the project folder to reinstall all the needed packages 
2. In ```appsettings.Development.json``` change the ConnectionString "db" to ```"db": "Server={server name};Database=IdentityServer;User ID={username of login};Password={password};trusted_connection=yes;TrustServerCertificate=true;"```
1. Run ```.\buildschema``` in the Visual Studio Developer PowerShell window
1. Run ```Update-Database -Context PersistedGrantDbContext``` and ```Update-Database -Context ConfigurationDbContext``` in the NuGet Package Manager Console


# Build Instructions for Server Deployment Coming Soon

# Necessary Dependencies
1. [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). Make sure to download the correct version for your system architecture.
