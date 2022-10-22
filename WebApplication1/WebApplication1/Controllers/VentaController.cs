using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVentas")]
        public List<Venta> Get()
        {
            return new List<Venta>();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Venta.EliminarVenta(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Venta ven)
        {
            ADO_Venta.ModificarVenta(ven);
        }
        [HttpPost]
        public void Agregar([FromBody] Venta ven)
        {
            ADO_Venta.AgregarVenta(ven);
        }
    }
}
