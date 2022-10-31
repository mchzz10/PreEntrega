using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> Get()
        {
            return new List<Usuario>();
        }

        [HttpGet("GetInicioSesion")]
        public Usuario Get(String nombre, String contraseña)
        {
            return ADO_Usuario.InicioSesion(nombre, contraseña);
        }
        [HttpGet("GetUsuario")]
        public Usuario Get(String nombre)
        {
            return ADO_Usuario.TraerUsuario(nombre);
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Usuario.EliminarUsuario(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Usuario usu)
        {
            ADO_Usuario.ModificarUsuario(usu);
        }
        [HttpPost]
        public void Agregar([FromBody] Usuario usu)
        {
            ADO_Usuario.AgregarUsuario(usu);
        }
    }
}
