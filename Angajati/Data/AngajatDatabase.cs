using Angajati.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angajati.Data
{
    public class AngajatDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public AngajatDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Angajat>().Wait();
        }

        public Task<List<Angajat>> GetAngajatiAsync()
        {
            return _database.Table<Angajat>().ToListAsync();
        }

        public Task<Angajat> GetAngajatAsync(int id)
        {
            return _database.Table<Angajat>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAngajatAsync(Angajat angajat)
        {
            if (angajat.Id != 0)
            {
                return _database.UpdateAsync(angajat);
            }
            else
            {
                return _database.InsertAsync(angajat);
            }
        }

        public Task<int> DeleteAngajatAsync(Angajat angajat)
        {
            return _database.DeleteAsync(angajat);
        }
    }
}
