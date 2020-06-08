using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class FrameworkContext : DbContext
    {
        private string _conncetionString;
        private string _migrationAssemblyName;

        public FrameworkContext(string connectionString, string migrationAssemblyName)
        {
            _conncetionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _conncetionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relation Between Group and Contact
            builder.Entity<Group>()
                .HasMany(g => g.Contacts)
                .WithOne(c => c.Group);

            base.OnModelCreating(builder);
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
