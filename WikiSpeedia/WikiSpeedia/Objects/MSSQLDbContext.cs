using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFrameworkCore;
using WikiSpeedia.Abstractions;
namespace WikiSpeedia.Objects
{
    public class MSSQLDbContext : DbContext
    {
        public MSSQLDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Page> Pages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var page = new Page
            {
                id = 2,
                title = "August",
                text = "yo"
            };
            modelBuilder.Entity<Page>().HasData(page);
        }
    }
}
