using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace multyPage_XamarinAssign.Pet
{
    public class PetDB
    {
        readonly SQLiteAsyncConnection _database;
        public PetDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pet>().Wait();
        }
        public Task<List<Pet>> GetPetsAsync()
        {
            return
            _database.Table<Pet>().ToListAsync();
        }
        public Task<int> SavePetAsync(Pet pet)
        {
            return _database.InsertAsync(pet);
        }
        public Task<Pet> GetPetAsync(int id)
        {
            return _database.Table<Pet>().Where(i => i.PetID == id).FirstOrDefaultAsync();
        }

        public Task<int> DeletePetAsync(Pet pet)
        {
            return _database.DeleteAsync(pet);
        }
        public Task<int> UpdatePetAsync(Pet pet)
        {
            if (pet.PetID != 0)
            {
                return _database.UpdateAsync(pet);
            }
            else
            {
                return _database.InsertAsync(pet);
            }
        }
    }
}
