using System.Data.Entity;
using App.Models;

namespace App.Context
{
    public class Context : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public Context() : base("DB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .HasMany(w => w.Workers)
                .WithMany(o => o.Organizations)
                .Map(m =>
                {
                    m.MapLeftKey("OrganizationId");
                    m.MapRightKey("WorkerId");
                    m.ToTable("OrganizationWorker");
                });
        }
    }
}
