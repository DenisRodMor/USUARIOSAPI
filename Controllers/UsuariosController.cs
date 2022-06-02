using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace USUARIOSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
       private static List<Usuarios> usuarios = new List<Usuarios>
            {
                new Usuarios{
                    Id = 1,
                    Nombre="Dennis",
                    Apellidos = "Rodriguez Mora",
                    Usuario = "Dejeromo",
                    Clave="123456",
                    Direccion="Alto Murillo",
                    Telefono="83655072",
                    TipodeUsuario="Administrador"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> Get()
        {
            
            return Ok(usuarios);
        }

      

        [HttpPost]
        public async Task<ActionResult<List<Usuarios>>> AddUsuario(Usuarios user)
        {
            usuarios.Add(user);
            return Ok(usuarios);
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuarios>>> UpdateUsuario(Usuarios request )
        {
            var user = usuarios.Find(u => u.Id == request.Id);
            if (user == null)
                return BadRequest("Usuario no encontrado");    
           
            user.Nombre = request.Nombre;
            user.Apellidos = request.Apellidos;
            user.Usuario = request.Usuario;
            user.Clave = request.Clave;
            user.Direccion = request.Direccion;
            user.Telefono = request.Telefono;
            user.TipodeUsuario = request.TipodeUsuario;
            return Ok(usuarios);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuarios>>> Delete(int id)
        {
            var user = usuarios.Find(u => u.Id == id);
            if (user == null)
                return BadRequest("Usuario no encontrado");
            usuarios.Remove(user);
            return Ok(usuarios);
        }
         

    }
}
