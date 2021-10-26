using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace multyPage_XamarinAssign
{
    public class userDB
    {
        readonly SQLiteAsyncConnection _database;
        public userDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }
        public Task<List<User>> GetPeopleAsync()
        {
            return
            _database.Table<User>().ToListAsync();
        }
        public Task<int> SavePersonAsync(User
        user)
        {
            return _database.InsertAsync(user);
        }
        public Task<User> GetItemAsync(string password, string username)
        {
            return _database.Table<User>().Where(i => i.username == username && i.password == password).FirstOrDefaultAsync();
        }

        public Task<int> DeleteItemAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
        public Task<int> UpdatePersonAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
    }
}
