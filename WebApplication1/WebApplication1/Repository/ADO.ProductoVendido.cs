using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using static WebApplication1.Controllers.ProductoVendidoController;

namespace WebApplication1.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> DevolverProductoVendido()
        {
            var listaProductosVendidos = new List<ProductoVendido>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM ProductoVendido";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var ProductoVendido = new ProductoVendido();

                    ProductoVendido.Id = Convert.ToInt32(reader2.GetValue(0));
                    ProductoVendido.Stock = Convert.ToInt32(reader2.GetValue(1));
                    ProductoVendido.IdVenta = Convert.ToInt32(reader2.GetValue(2));
                    ProductoVendido.IdProducto = Convert.ToInt32(reader2.GetValue(3));


                    listaProductosVendidos.Add(ProductoVendido);

                }
                reader2.Close();
                connection.Close();

            }
            return listaProductosVendidos;
        }

        public static void AgregarProductoVendido(ProductoVendido proven)
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
                cmd.CommandText = "Insert into producto(Stock, IdProducto, IdVenta)" +
                    " Values (@Stock, @IdProducto, @IDVenta)";

                var parametrostock = new SqlParameter();
                parametrostock.ParameterName = "Stock";
                parametrostock.SqlDbType = SqlDbType.Int;
                parametrostock.Value = proven;

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "IdProducto";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = proven;

                var parametroidven = new SqlParameter();
                parametroidven.ParameterName = "IdVenta";
                parametroidven.SqlDbType = SqlDbType.BigInt;
                parametroidven.Value = proven;

                cmd.Parameters.Add(parametrostock);
                cmd.Parameters.Add(parametroid);
                cmd.Parameters.Add(parametroidven);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void EliminarProductoVendido(int id)
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
                cmd.CommandText = "DELETE FROM ProductoVendido where id = @idpro";

                var parametro = new SqlParameter();
                parametro.ParameterName = "idpro";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarProductoVendido(ProductoVendido proven)
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
                cmd.CommandText = "UPDATE ProductoVendido SET Stock = @Stock, IdProducto = @IdProducto, IdVenta =  @IdVenta where Id = @idpro)";

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "Idpro";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = proven;

                var parametrostock = new SqlParameter();
                parametrostock.ParameterName = "Stock";
                parametrostock.SqlDbType = SqlDbType.Int;
                parametrostock.Value = proven;

                var parametroidpro = new SqlParameter();
                parametroidpro.ParameterName = "IdProducto";
                parametroidpro.SqlDbType = SqlDbType.BigInt;
                parametroidpro.Value = proven;

                var parametroidven = new SqlParameter();
                parametroidven.ParameterName = "IdVenta";
                parametroidven.SqlDbType = SqlDbType.BigInt;
                parametroidven.Value = proven;

                cmd.Parameters.Add(parametrostock);
                cmd.Parameters.Add(parametroidpro);
                cmd.Parameters.Add(parametroidven);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
