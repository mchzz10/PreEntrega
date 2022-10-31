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

                connection.Open();
                SqlCommand cmd1 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM ProductoVendido";
                var reader1 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var ProductoVendido = new ProductoVendido();

                    ProductoVendido.Id = Convert.ToInt32(reader2.GetValue(0));
                    ProductoVendido.Stock = Convert.ToInt32(reader2.GetValue(1));
                    ProductoVendido.IdVenta = Convert.ToInt32(reader2.GetValue(2));
                    ProductoVendido.IdProducto = Convert.ToInt32(reader2.GetValue(3));
                }
                reader2.Close();
                connection.Close();
            }
            return listVentas;
        }

        public static void AgregarVenta(Venta ventas)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            long idVenta;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Venta] (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); Select scope_identity();", connection);
                cmd.CommandType = CommandType.Text;
                
                
                cmd.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.NVarChar)).Value = ventas.Comentarios;
                cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt)).Value = ventas.IdUsuario;

                idVenta = Convert.ToInt64(cmd.ExecuteScalar());

                //INSERT en tabla producto vendido con lista de productos enviados
                foreach (ProductoVendido producto in ventas.Productos)
                {
                    //Agregar Venta
                    cmd = new SqlCommand("INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta)  VALUES   (@Stock,@IdProducto,@IdVenta) ", connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt)).Value = idVenta;
                    cmd.ExecuteNonQuery();
                    //Actualizar Stock en Productos
                    cmd = new SqlCommand("UPDATE Producto SET Stock = Stock - @Stock WHERE idProducto = @IdProducto", connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int)).Value = producto.Stock;
                    cmd.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt)).Value = producto.IdProducto;
                    cmd.ExecuteNonQuery();
                }
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
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = "DELETE FROM ProductoVendido where id = @id";

                var parametro1 = new SqlParameter();
                parametro1.ParameterName = "id";
                parametro1.SqlDbType = SqlDbType.BigInt;
                parametro1.Value = id;

                cmd1.Parameters.Add(parametro1);
                cmd1.ExecuteNonQuery();
                connection.Close();

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
