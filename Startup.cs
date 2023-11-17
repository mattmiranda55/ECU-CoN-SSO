using Duende.IdentityServer.Configuration;
using Duende.IdentityServer.EntityFramework.DbContexts;
using ECU_CoN_SSO;
using ECU_CoN_SSO.Pages.Admin.ApiScopes;
using ECU_CoN_SSO.Pages.Admin.Clients;
using ECU_CoN_SSO.Pages.Admin.IdentityScopes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.ConfigureServices();
        app.ConfigurePipeline();
        services.AddControllersWithViews();
        services.AddScoped<ClientRepository>();
        services.AddScoped<ApiScopeRepository>();
        services.AddScoped<IdentityScopeRepository>();
        services.AddDbContext<ConfigurationDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("db"));
        });
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
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; connect-src 'self' wss://localhost:44342/ECU-CoN-SSO/;");
            await next();
        });

        // Configure other middleware and routing
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseIdentityServer();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
            endpoints.MapRazorPages().RequireAuthorization();
        });
        
        
    }
}
