using System.Collections.Generic;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Models;
using SQLite;

namespace multyPage_XamarinAssign.Database
{
    public class DBPetClinic
    {
        private readonly SQLiteAsyncConnection _database;

        public DBPetClinic(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Vet>().Wait();
            _database.CreateTableAsync<Pet>().Wait();
            _database.CreateTableAsync<Owner>().Wait();
        }

        //User
        public Task<List<User>> GetUsersAsync()
        {
            return
                _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<int> UpdateUserAsync(User user)
        {
            if (user.UserId != 0)
                return _database.UpdateAsync(user);
            return _database.InsertAsync(user);
        }

        public Task<int> DeleteUserAsync(int id)
        {
            return _database.DeleteAsync<User>(id);
        }

        public Task<User> GetUserById(int userId)
        {
            return _database.Table<User>().Where(i => i.UserId == userId).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByUsernamePassword(string username, string password)
        {
            return _database.Table<User>().Where(i => i.Username == username && i.Password == password)
                .FirstOrDefaultAsync();
        }

        //Owners

        public Task<List<Owner>> GetOwnersAsync()
        {
            return
                _database.Table<Owner>().ToListAsync();
        }

        public Task<int> SaveOwnerAsync(Owner owner)
        {
            return _database.InsertAsync(owner);
        }

        public Task<int> UpdateOwnerAsync(Owner owner)
        {
            if (owner.OwnerId != 0)
                return _database.UpdateAsync(owner);
            return _database.InsertAsync(owner);
        }

        public Task<int> DeleteOwnerAsync(Owner owner)
        {
            return _database.DeleteAsync(owner);
        }

        public Task<Owner> GetOwnerById(int ownerId)
        {
            return _database.Table<Owner>().Where(i => i.OwnerId == ownerId).FirstOrDefaultAsync();
        }

        //Vet
        public Task<List<Vet>> GetVetsAsync()
        {
            return
                _database.Table<Vet>().ToListAsync();
        }

        public Task<int> SaveVetAsync(Vet vet)
        {
            return _database.InsertAsync(vet);
        }

        //Pet
        public Task<List<Pet>> GetPetsAsync()
        {
            return _database.Table<Pet>().ToListAsync();
        }

        public Task<int> SavePetAsync(Pet pet)
        {
            return _database.InsertAsync(pet);
        }

        public Task<Pet> GetPetById(int petId)
        {
            return _database.Table<Pet>().Where(i => i.PetId == petId).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> UpdatePetAsync(Pet pet)
        {
            if (pet.PetId != 0)
                return _database.UpdateAsync(pet);
            return _database.InsertAsync(pet);
        }
    }
}