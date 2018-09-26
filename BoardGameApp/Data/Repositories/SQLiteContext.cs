using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    class SQLiteContext : DbContext
    {
        private static bool _created = false;
        private string _dbPath;

        public SQLiteContext(string dbPath)
        {
            _dbPath = dbPath;
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        public DbSet<BoardGame> BoardGames { get; set; }
    }
}
