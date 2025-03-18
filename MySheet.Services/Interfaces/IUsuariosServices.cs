using MongoDB.Bson;
using MySheet.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Services.Interfaces
{
    public interface IUsuariosServices
    {
        Task CriarUsuario(Usuarios usuario);
        Task<List<Usuarios>> GetAll();
        Task<Usuarios> GetUser(ObjectId id);
    }
}
