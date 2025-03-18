using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MySheet.Domain.Entidades;
using MySheet.Infra.DataAccess.Concrete;
using MySheet.Services.Interfaces;

namespace MySheet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;

        public UsuariosController(IUsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }

        [HttpPost]
        public IActionResult CreateUser(Usuarios user)
        {
            try
            {
                _usuariosServices.CriarUsuario(user);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _usuariosServices.GetAll();

            return Ok(users.Result);
        }

        [HttpGet]
        [Route("Usuarios/GetUser/{id?}")]
        public IActionResult GetUsuario(string id)
        {
            try
            {
                var novoId = new ObjectId(id);  //ObjectId.TryParse(id, out ObjectId idParsed) ? idParsed : throw new InvalidDataException();

                var user = _usuariosServices.GetUser(novoId);

                if (user == null) return NotFound();
                else return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
