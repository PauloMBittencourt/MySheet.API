using MongoDB.Bson;
using MongoDB.Driver;
using MySheet.Domain.Entidades;
using MySheet.Infra.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Infra.DataAccess.Concrete
{
    public class UsuariosDataAccess : IUsuariosDataAccess
    {
        private readonly DbAccess _dataAccess;
        private const string _collection = "User";

        public UsuariosDataAccess(DbAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<Usuarios>> GetAllUsers()
        {
            var users = await _dataAccess.GetAll<Usuarios>(_collection);

            return users;
        }
        public async Task<Usuarios> GetUserById(ObjectId id)
        {
            var userCollection = _dataAccess.ConnectToMongo<Usuarios>(_collection);
            var filter = Builders<Usuarios>.Filter.Eq("_id", id);

            var a = await userCollection.Find(filter).FirstOrDefaultAsync();

            return a;
        }

        public Task Create(Usuarios user)
        {
            var userCollection = _dataAccess.ConnectToMongo<Usuarios>(_collection);
            return userCollection.InsertOneAsync(user);
        }

        public Task Edit(Usuarios user)
        {
            var userCollection = _dataAccess.ConnectToMongo<Usuarios>(_collection);
            var filter = Builders<Usuarios>.Filter.Eq("_id", user._id);
            return userCollection.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<bool> Delete(Usuarios user)
        {
            var userCollection = _dataAccess.ConnectToMongo<Usuarios>(_collection);
            var filter = Builders<Usuarios>.Filter.Eq("_id", user._id);

            var existingUser = await userCollection.Find(filter).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                existingUser.Status = false;

                await userCollection.ReplaceOneAsync(filter, existingUser);

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
