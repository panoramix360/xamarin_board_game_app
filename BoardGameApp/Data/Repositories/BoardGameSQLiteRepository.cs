using DomainModel.Entities;
using DomainModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BoardGameSQLiteRepository : IBoardGameRepository
    {
        private SQLiteContext _db;

        public BoardGameSQLiteRepository(string devicePlatform)
        {
            string dbPath = String.Empty;

            switch (devicePlatform)
            {
                case "UWP":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "boardgames.sqlite");
                    break;
                case "iOS":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "data", "boardgames.sqlite");
                    break;
                case "Android":
                    dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "boardgames.sqlite");
                    break;
            }

            _db = new SQLiteContext(dbPath);
        }

        public BoardGame Get(Guid id)
        {
            return _db.BoardGames.SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<BoardGame> GetAll()
        {
            return _db.BoardGames;
        }

        public void Add(BoardGame boardGame)
        {
            _db.BoardGames.Add(boardGame);
            _db.SaveChanges();
        }

        public void Update(BoardGame boardGame)
        {
            //##### Update the LocalDatabase #####
            var entry = _db.Entry(boardGame);
            _db.BoardGames.Attach(boardGame);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
            //####################################
        }

        public void SaveAll(IEnumerable<BoardGame> games)
        {
            _db.BoardGames.AddRange(games);
            _db.SaveChanges();
        }

        public void RemoveAll()
        {
            foreach (var item in _db.BoardGames)
                _db.BoardGames.Remove(item);
            _db.SaveChanges();
        }
    }
}
