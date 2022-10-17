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
    public class Ado_Producto
    {
        // B_ Metodo para traer los productos cargados por un usuario en particular.

        public List<Producto> GetproductoByIdUsuario(int IdUsuario)
        {
            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "DESKTOP-O2006PP";
            connectionStringBuilder.InitialCatalog = "SistemaGestion";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                var comando = new SqlCommand("select * from Producto where IdUsuario = @IdUsu", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "IdUsu";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = IdUsuario;

                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var produc = new Producto();

                    produc.id = Convert.ToInt32(reader.GetValue(0));
                    produc.descripciones = reader.GetValue(1).ToString();
                    produc.costo = Convert.ToDouble(reader.GetValue(2));
                    produc.precioVenta = Convert.ToDouble(reader.GetValue(3));
                    produc.stock = Convert.ToInt32(reader.GetValue(4));
                    produc.idUsuario = reader.GetValue(5).ToString();

                    listaProductos.Add(produc);
                }

                reader.Close();
            }
            return listaProductos;
        }
    }
}