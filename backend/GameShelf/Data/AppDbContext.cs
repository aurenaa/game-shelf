using GameShelf.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameShelf.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; } = null!;
    }
}