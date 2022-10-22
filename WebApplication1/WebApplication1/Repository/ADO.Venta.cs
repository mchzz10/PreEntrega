using static WebApplication1.Controllers.VentaController;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Data;

namespace WebApplication1.Repository
{
    public class ADO_Venta
    {
        public static List<Venta> DevolverVentas()
        {
            var listVentas = new List<Venta>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Venta";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var Venta = new Venta();

                    Venta.Id = Convert.ToInt32(reader2.GetValue(0));
                    Venta.Comentarios = reader2.GetValue(1).ToString();
                    Venta.IdUsuario = Convert.ToInt32(reader2.GetValue(2));

                    listVentas.Add(Venta);

                }
                reader2.Close();
                connection.Close();

            }
            return listVentas;
        }

        public static void AgregarVenta(Venta ven)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into venta(Comentarios, IdUsuario)" +
                    " Values (@Comentarios, @IdUsuario)";

                var parametrocomen = new SqlParameter();
                parametrocomen.ParameterName = "Stock";
                parametrocomen.SqlDbType = SqlDbType.Int;
                parametrocomen.Value = ven;

                var parametroidusu = new SqlParameter();
                parametroidusu.ParameterName = "IdUsuario";
                parametroidusu.SqlDbType = SqlDbType.BigInt;
                parametroidusu.Value = ven;

                cmd.Parameters.Add(parametrocomen);
                cmd.Parameters.Add(parametroidusu);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void EliminarVenta(int id)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Venta where id = @id";

                var parametro = new SqlParameter();
                parametro.ParameterName = "id";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarVenta(Venta ven)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario where Id = @idpro)";

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "Idpro";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = ven;

                var parametrocomen = new SqlParameter();
                parametrocomen.ParameterName = "Stock";
                parametrocomen.SqlDbType = SqlDbType.Int;
                parametrocomen.Value = ven;

                var parametroidusu = new SqlParameter();
                parametroidusu.ParameterName = "IdProducto";
                parametroidusu.SqlDbType = SqlDbType.BigInt;
                parametroidusu.Value = ven;

                cmd.Parameters.Add(parametrocomen);
                cmd.Parameters.Add(parametroidusu);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
