using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.SHC.Models;

namespace Web.SHC
{
    public class SHCContext: DbContext
    {
        public SHCContext() : base("name=SHCDB")
        {
            Database.SetInitializer<SHCContext>(new CreateDatabaseIfNotExists<SHCContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasIndex(p => p.MovieID).IsUnique(false).HasName("Index_MovieID");
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movies> Movies { get; set; }
    }
}