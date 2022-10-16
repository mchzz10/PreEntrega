using Mauro_Chazarreta.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauro_Chazarreta.Handlers
{
    public class Ado_ProductoVendido
    {
        // C_ Metodo para traer los productos vendidos por un usuario.
        public List<ProductoDto> GetProductosVendidosByUsuario()
        {
            var listaProductos = new List<ProductoDto>();

            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "DESKTOP-O2006PP";
            connectionStringBuilder.InitialCatalog = "SistemaGestion";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                var comando = new SqlCommand("select * from venta where v.IdVenta = @IdUsu", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "IdUsu";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = 1;

                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var producto = new ProductoDto();

                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Stock = Convert.ToInt32(reader.GetValue(2));

                    listaProductos.Add(producto);
                }

                Console.WriteLine("-----Productos Vendidos por el usuario-----");
                foreach (var produc in listaProductos)
                {
                    Console.WriteLine("*Id = " + produc.Id);
                    Console.WriteLine("*Descripciones = " + produc.Descripciones);
                    Console.WriteLine("*Stock = " + produc.Stock);

                    Console.WriteLine("________________");
                }
                reader.Close();
            }
        
            return new List<ProductoDto>();
        }
    }
}
