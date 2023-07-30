using CityApiCom.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CityApiCom.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          /*  modelBuilder.Entity<Country>()
                .HasKey(p => p.CountryRegion);*/

            modelBuilder.Entity<Country>()
                .HasOne(p => p.Region)
                .WithMany()
                .HasForeignKey(c => c.RegionId);

            /*       modelBuilder.Entity<Country>(ent => {
                       ent.HasOne(p => p.Region)
                       .WithMany(pc => pc.Name)
                       .HasForeignKey(k => k.Id);
                   });*/
            /*
                        modelBuilder.Entity<Country>()
                            .HasKey(p => new { p.Id, p.Region });
                        modelBuilder.Entity<Region>()
                            .HasKey(p => new { p.Id });
                        modelBuilder.Entity<Country>()
                            .HasOne(p => p.Region)
                            .WithOne()
                            .HasForeignKey()*/
        }

    }
}
