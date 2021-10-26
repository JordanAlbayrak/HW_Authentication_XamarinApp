using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace multyPage_XamarinAssign.Vet
{
    public class VetDB
    {
        readonly SQLiteAsyncConnection _database;
        public VetDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Vet>().Wait();
        }
        public Task<List<Vet>> GetVetsAsync()
        {
            return
            _database.Table<Vet>().ToListAsync();
        }
        public Task<int> SaveVetAsync(Vet
        vet)
        {
            return _database.InsertAsync(vet);
        }
        public Task<Vet> GetVetAsync(int id)
        {
            return _database.Table<Vet>().Where(i => i.VetID == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteVetAsync(Vet vet)
        {
            return _database.DeleteAsync(vet);
        }
        public Task<int> UpdateVetAsync(Vet vet)
        {
            if (vet.VetID != 0)
            {
                return _database.UpdateAsync(vet);
            }
            else
            {
                return _database.InsertAsync(vet);
            }
        }
    }
}
