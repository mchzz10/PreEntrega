using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductoVendido")]
        public List<ProductoVendido> Get()
        {
            return new List<ProductoVendido>();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_ProductoVendido.EliminarProductoVendido(id);
        }
        [HttpPut]
        public void Modificar([FromBody] ProductoVendido proven)
        {
            ADO_ProductoVendido.ModificarProductoVendido(proven);
        }
        [HttpPost]
        public void Agregar([FromBody] ProductoVendido proven)
        {
            ADO_ProductoVendido.AgregarProductoVendido(proven);
        }
    }
}
