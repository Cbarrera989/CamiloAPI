using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CamiloAPI.Data.Models;

namespace CamiloAPI.Data
{
    public class CamiloAPIContext : DbContext
    {
        public CamiloAPIContext (DbContextOptions<CamiloAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CamiloAPI.Data.Models.Client> Clients { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            //modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            //modelBuilder.Entity<User>().ToTable(nameof(User));

            base.OnModelCreating(modelBuilder);
        }

    }
}
