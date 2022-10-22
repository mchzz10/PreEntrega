using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;
using static WebApplication1.Controllers.ProductoController;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> Get()
        {
            return new List<Producto>();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Producto.EliminarProducto(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Producto pro)
        {
            ADO_Producto.ModificarProducto(pro);
        }
        [HttpPost]
        public void Agregar([FromBody] Producto pro)
        {
            ADO_Producto.AgregarProducto(pro);
        }
    }
}