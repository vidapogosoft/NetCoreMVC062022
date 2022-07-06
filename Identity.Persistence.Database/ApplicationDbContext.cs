using Identity.Model;
using Identity.Persistence.Database.Configuration;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Identity.Persistence.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public ApplicationDbContext(
            
            DbContextOptions<ApplicationDbContext> options

            ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Database Schema
            builder.HasDefaultSchema("Identity");

            //Model constraints
            ModelConfig(builder);
           
        }

        private void ModelConfig (ModelBuilder modelBuilder)
        {
            new ApplicationUserConfiguration(modelBuilder.Entity<ApplicationUser>());
            new ApplicationRoleConfiguration(modelBuilder.Entity<ApplicationRole>());
        }

    }
}
