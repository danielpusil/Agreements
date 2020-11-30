using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AgreementContext : IdentityDbContext<User>
    {
        public AgreementContext(DbContextOptions options):base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agreement>().HasKey(ci=> new {ci.AgreementId});
        }

        public DbSet<Agreement> Agreement{get;set;}
    }
}