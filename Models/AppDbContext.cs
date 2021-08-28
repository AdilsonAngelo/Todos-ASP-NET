using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Todos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(p => p.Title)
                .HasMaxLength(100);

            modelBuilder.Entity<Todo>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Todo>()
                .HasData(
                    new Todo { Id = 1, Title = "Shopping list", Description = "tomato, onions, sauce"}
                );
        }
    }
}
