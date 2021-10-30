﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace multyPage_XamarinAssign
{
    public class DBPetClinic
    {
        readonly SQLiteAsyncConnection _database;
        public DBPetClinic(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Vet>().Wait();
            _database.CreateTableAsync<Pet>().Wait();

        }
        public Task<List<User>> GetAsync()
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
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }        
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<User> GetItemAsyncById(int userId)
        {
            return _database.Table<User>().Where(i => i.UserId == userId).FirstOrDefaultAsync();
        }

        public Task<User> GetItemAsync(string username, string password)
        {
            return _database.Table<User>().Where(i => i.Username == username && i.Password == password).FirstOrDefaultAsync();
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

        public Task<List<User>> GetUserAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
    }
}