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
    internal class ADO_Venta
    {
        // D_ Metodo para traer ventas filtrando por la Id de un usuario.
        public List<Venta> GetProductosVendidosByUsuario(int IdUsuario)
        {
            var ventas = new List<Venta>();

            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "DESKTOP-O2006PP";
            connectionStringBuilder.InitialCatalog = "SistemaGestion";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                var comando = new SqlCommand("select * from venta where IdUsuario = @IdUsu", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "IdUsu";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = IdUsuario;

                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var venta = new Venta();
                    venta.id = Convert.ToInt32(reader.GetValue(0));
                    venta.comentarios = reader.GetValue(1).ToString();
                    venta.idUsuario = Convert.ToInt32(reader.GetValue(2));

                    ventas.Add(venta);

                }
                reader.Close();
            }

            return ventas;
        }
    }
}
