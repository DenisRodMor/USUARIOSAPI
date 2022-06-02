using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace USUARIOSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
       
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> GetUsuario()
        {
            
            return Ok(await _context.Usuarios.ToListAsync());
        }

      

        [HttpPost]
        public async Task<ActionResult<List<Usuarios>>> AddUsuario(Usuarios user)
        {
           _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuarios>>> UpdateUsuario(Usuarios request )
        {
            var dbusuarios = await _context.Usuarios.FindAsync(request.Id);
            if (dbusuarios == null)
                return BadRequest("Usuario no encontrado");

            dbusuarios.Nombre = request.Nombre;
            dbusuarios.Apellidos = request.Apellidos;
            dbusuarios.Usuario = request.Usuario;
            dbusuarios.Clave = request.Clave;
            dbusuarios.Direccion = request.Direccion;
            dbusuarios.Telefono = request.Telefono;
            dbusuarios.TipodeUsuario = request.TipodeUsuario;

            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuarios>>> Delete(int id)
        {
            var dbusuarios = await _context.Usuarios.FindAsync(id);
            if (dbusuarios == null)
                return BadRequest("Usuario no encontrado");
           _context.Usuarios.Remove(dbusuarios);
            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());
        }
         

    }
}
