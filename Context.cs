using Microsoft.EntityFrameworkCore;
using ECU_CoN_SSO.Pages.Portal;
using ECU_CoN_SSO.Pages.Admin.ApiScopes;
using ECU_CoN_SSO.Pages.Admin.IdentityScopes;

namespace ECU_CoN_SSO 
{
    public class ECUDbContext : DbContext
    {
        public ECUDbContext(DbContextOptions<ECUDbContext> options) : base(options)
        {
        }

        public DbSet<ClientRepository> ClientRepositories { get; set; }

        public DbSet<IdentityScopeRepository> IdentityScopeRepositories { get; set; }
        public DbSet<ApiScopeRepository> ApiScopeRepositories { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ClientRepository>()
        //        .HasKey(e => e.Id); // Example: Setting primary key

        //    modelBuilder.Entity<IdentityScopeRepository>()
        //        .HasKey(e => e.Id); // Example: Setting primary key

        //    modelBuilder.Entity<ApiScopeRepository>()
        //        .HasKey(e => e.Id); // Example: Setting primary key


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
