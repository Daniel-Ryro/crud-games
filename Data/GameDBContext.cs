using CrudAPI.Data.Map;
using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Data
{
    public class GameDBContext : DbContext
    {
        public GameDBContext(DbContextOptions<GameDBContext> options)
            : base(options)
        { 
        }

        public DbSet<GamesModel> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
