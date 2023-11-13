using Duende.IdentityServer.Configuration;
using ECU_CoN_SSO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentityServer(options =>
        {
            // Configure IdentityServer options here
        })
        .AddInMemoryClients(Config.Clients)  // Example: Configure your clients
        .AddInMemoryIdentityResources(Config.IdentityResources)  // Example: Configure your identity resources
        .AddInMemoryApiScopes(Config.ApiScopes)  // Example: Configure your API scopes
        .AddTestUsers(TestUsers.Users);
        services.AddAuthorization();
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        //else
        //{
        //    // Configure production-specific behavior
        //}


        // Configure other middleware and routing
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages().RequireAuthorization();
        });
        app.UseIdentityServer();
        app.UseStaticFiles();
    }
}
