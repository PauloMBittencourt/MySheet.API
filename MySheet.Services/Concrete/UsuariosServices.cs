using MongoDB.Bson;
using MySheet.Domain.Entidades;
using MySheet.Infra.DataAccess.Interfaces;
using MySheet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Services.Concrete
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuariosDataAccess _usuariosDataAccess;

        public UsuariosServices(IUsuariosDataAccess usuariosDataAccess)
        {
            _usuariosDataAccess = usuariosDataAccess;
        }

        public Task<List<Usuarios>> GetAll() => _usuariosDataAccess.GetAllUsers();

        public Task<Usuarios> GetUser(ObjectId id)
        {
            var user = _usuariosDataAccess.GetUserById(id);

            if (user == null) return null;
            else return user;
        }

        public Task CriarUsuario(Usuarios usuario) => _usuariosDataAccess.Create(usuario);
    }
}
