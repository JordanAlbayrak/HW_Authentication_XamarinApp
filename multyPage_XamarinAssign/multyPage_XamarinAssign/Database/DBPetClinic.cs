using System.Collections.Generic;
using System.Threading.Tasks;
using multyPage_XamarinAssign.Models;
using Firebase.Database;
using Newtonsoft.Json;
using System;

using System.IO;
using System.Linq;


namespace multyPage_XamarinAssign.Database
{
    public class DBPetClinic
    {
        FirebaseClient firebaseClient =
            new FirebaseClient
            ("https://petclinicxamarin-default-rtdb.firebaseio.com/");

        //User
        public async Task<List<User>> GetUsersAsync()
        {
            return (await firebaseClient.
                Child(nameof(User)).OnceAsync<User>()).Select(
                item => new User
                {
                    UserId = item.Key,
                    Username = item.Object.Username,
                    FirstName = item.Object.FirstName,
                    LastName = item.Object.LastName,
                    Email = item.Object.Email,
                    Phone = item.Object.Phone,
                    Password = item.Object.Password,
                    Role = item.Object.Role,
                    IsRead = item.Object.IsRead,
                    IsWrite = item.Object.IsWrite,
                    IsDelete = item.Object.IsDelete,
                }).ToList();
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            var data = await firebaseClient.Child(nameof(User)).
            PostAsync(JsonConvert.SerializeObject(user));
            if (!String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            await firebaseClient.Child(nameof(User)
                      + "/" + user.UserId).
                      PutAsync(JsonConvert.SerializeObject(user));
            return true;
        }

        public async Task<bool> DeleteUserAsync(string userid)
        {
            await firebaseClient.Child(nameof(User)
              + "/" + userid).DeleteAsync();
            return true;
        }

        public async Task<User> GetUserById(string userId)
        {
            return (await firebaseClient.Child(nameof(User)
        + "/" + userId).OnceSingleAsync<User>());
        }

        public async Task<User> GetUserByUsernamePassword(string username, string password)
        {
            return (await firebaseClient.Child(nameof(User)).OnceAsync<User>()).Select(item => new User
            {
                Username = item.Object.Username,
                Password = item.Object.Password,
                FirstName = item.Object.FirstName,
                LastName = item.Object.LastName,
                Email = item.Object.Email,
                Phone = item.Object.Phone,
                Role = item.Object.Role,
                IsRead = item.Object.IsRead,
                IsWrite = item.Object.IsWrite,
                IsDelete = item.Object.IsDelete,

            }).FirstOrDefault(i => i.Username == username && i.Password == password);

        }

        //Owners

        public async Task<List<Owner>> GetOwnersAsync()
        {
            //reading the firebaseClient.Child to fill/create the list
            return (await firebaseClient.
                Child(nameof(Owner)).OnceAsync<Owner>()).Select(
                item => new Owner
                {
                    OwnerId = item.Object.OwnerId,
                    OwnerLastName = item.Object.OwnerLastName,
                    OwnerFirstName = item.Object.OwnerFirstName,
                    OwnerPhoneNumber = item.Object.OwnerPhoneNumber,
                    PetId1 = item.Object.PetId1,
                    PetId2 = item.Object.PetId2,
                }).ToList();
        }

        public async Task<bool> SaveOwnerAsync(Owner owner)
        {
            var data = await firebaseClient.Child(nameof(Owner)).
            PostAsync(JsonConvert.SerializeObject(owner));
            if (!String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateOwnerAsync(Owner owner)
        {
            await firebaseClient.Child(nameof(Owner)
                      + "/" + owner.OwnerId).
                      PutAsync(JsonConvert.SerializeObject(owner));
            return true;
        }

        public async Task<bool> DeleteOwnerAsync(Owner ownerId)
        {
            await firebaseClient.Child(nameof(Owner)
    + "/" + ownerId).DeleteAsync();
            return true;
        }

        public async Task<Owner> GetOwnerById(string ownerId)
        {
            return (await firebaseClient.Child(nameof(Owner)
            + "/" + ownerId).OnceSingleAsync<Owner>());
        }

        //Vet
        public async Task<List<Vet>> GetVetsAsync()
        {
            return (await firebaseClient.
              Child(nameof(Vet)).OnceAsync<Vet>()).Select(
              item => new Vet
              {
                  VetId = item.Key,
                  FirstName = item.Object.FirstName,
                  LastName = item.Object.LastName,
                  Email = item.Object.Email,
                  Phone = item.Object.Phone,
                  Special = item.Object.Special,
              }).ToList();
        }

        public async Task<bool> SaveVetAsync(Vet vet)
        {
            var data = await firebaseClient.Child(nameof(Vet)).
                     PostAsync(JsonConvert.SerializeObject(vet));
            if (!String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Pet
        public async Task<List<Pet>> GetPetsAsync()
        {
            return (await firebaseClient.
              Child(nameof(Pet)).OnceAsync<Pet>()).Select(
              item => new Pet
              {
                  PetId = item.Key,
                  PetName = item.Object.PetName,
                  PetType = item.Object.PetType,
              }).ToList();
        }

        public async Task<bool> SavePetAsync(Pet pet)
        {
            var data = await firebaseClient.Child(nameof(Pet)).
            PostAsync(JsonConvert.SerializeObject(pet));
            if (!String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Pet> GetPetById(int petId)
        {
            return (await firebaseClient.Child(nameof(Pet)
                    + "/" + petId).OnceSingleAsync<Pet>());
        }

        public async Task<List<User>> GetUserAsync()
        {
            return (await firebaseClient.
            Child(nameof(User)).OnceAsync<User>()).Select(
            item => new User
            {
                UserId = item.Key,
                Username = item.Object.LastName,
                FirstName = item.Object.FirstName,
                LastName = item.Object.Email,
                Email = item.Object.Email,
                Phone = item.Object.Phone,
                Password = item.Object.Password,
                Role = item.Object.Role,
                IsRead = item.Object.IsRead,
                IsWrite = item.Object.IsWrite,
                IsDelete = item.Object.IsDelete,
            }).ToList();
        }

        public async Task<bool> UpdatePetAsync(Pet pet)
        {
            await firebaseClient.Child(nameof(Pet)
                + "/" + pet.PetId).
                PutAsync(JsonConvert.SerializeObject(pet));
            return true;
        }
        
        // delete vet
        public async Task<bool> DeleteVetAsync(string vetId)
        {
            await firebaseClient.Child(nameof(Vet)
                + "/" + vetId).DeleteAsync();
            return true;
        }

        // get vet by id
        public async Task<Vet> GetVetById(string vetId)
        {
            return (await firebaseClient.Child(nameof(Vet)
           + "/" + vetId).OnceSingleAsync<Vet>());
        }
        
        // update vet by id
        public async Task<bool> UpdateVetAsync(Vet vet)
        {

            await firebaseClient.Child(nameof(Vet)
                + "/" + vet.VetId).
                PutAsync(JsonConvert.SerializeObject(vet));
            return true;
        }
        
    }
}