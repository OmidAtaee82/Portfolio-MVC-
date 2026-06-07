using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class PortfolioDB:DbContext
    {

        public PortfolioDB(DbContextOptions options):base(options)
        {

        }

        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AboutMe>().ToTable("AboutMe");
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Projects>().ToTable("Projects");
            modelBuilder.Entity<Experience>().ToTable("Experience");
            modelBuilder.Entity<Contact>().ToTable("Contact");
        }

    }
}
