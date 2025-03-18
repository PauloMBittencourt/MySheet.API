using MongoDB.Bson;
using MySheet.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Infra.DataAccess.Interfaces
{
    public interface IUsuariosDataAccess
    {
        public Task Create(Usuarios user);
        public Task<bool> Delete(Usuarios user);
        public Task Edit(Usuarios user);
        public Task<List<Usuarios>> GetAllUsers();
        Task<Usuarios> GetUserById(ObjectId id);
    }
}
