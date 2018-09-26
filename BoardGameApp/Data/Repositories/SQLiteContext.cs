using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    class SQLiteContext : DbContext
    {
        private string _dbPath;

        public SQLiteContext(string dbPath)
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        public DbSet<BoardGame> BoardGames { get; set; }
    }
}
