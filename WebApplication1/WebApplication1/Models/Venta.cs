namespace WebApplication1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }
        public IEnumerable<ProductoVendido> Productos { get; internal set; }
    }
}
