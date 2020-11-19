using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static System.Console;

namespace ConsoleApp.Context
{
    public class ConsoleContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("ConnectionStringHere")
                .LogTo(WriteLine, new[] { RelationalEventId.CommandExecuted })
                .EnableSensitiveDataLogging();
        }
    }
}
