using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> DevolverProductos()
        {
            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Producto";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var producto = new Producto();

                    producto.Id = Convert.ToInt32(reader2.GetValue(0));
                    producto.Descripciones = reader2.GetValue(1).ToString();
                    producto.Costo = Convert.ToInt32(reader2.GetValue(2));
                    producto.PrecioVenta = Convert.ToInt32(reader2.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader2.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader2.GetValue(5));

                    listaProductos.Add(producto);

                }
                reader2.Close();
                connection.Close();

            }
            return listaProductos;
        }

        public static void AgregarProducto(Producto pro)
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
                cmd.CommandText = "Insert into producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    " Values (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                var parametrodes = new SqlParameter();
                parametrodes.ParameterName = "Descripciones";
                parametrodes.SqlDbType = SqlDbType.VarChar;
                parametrodes.Value = pro.Descripciones;

                var parametrocos = new SqlParameter();
                parametrocos.ParameterName = "Costo";
                parametrocos.SqlDbType = SqlDbType.Money;
                parametrocos.Value = pro.Costo;

                var parametropreven = new SqlParameter();
                parametropreven.ParameterName = "PrecioVenta";
                parametropreven.SqlDbType = SqlDbType.Money;
                parametropreven.Value = pro.PrecioVenta;

                var parametrostock = new SqlParameter();
                parametrostock.ParameterName = "Stock";
                parametrostock.SqlDbType = SqlDbType.Int;
                parametrostock.Value = pro.Stock;

                var parametroidUsu = new SqlParameter();
                parametroidUsu.ParameterName = "IdUsuario";
                parametroidUsu.SqlDbType = SqlDbType.BigInt;
                parametroidUsu.Value = pro.IdUsuario;

                cmd.Parameters.Add(parametrodes);
                cmd.Parameters.Add(parametrocos);
                cmd.Parameters.Add(parametropreven);
                cmd.Parameters.Add(parametrostock);
                cmd.Parameters.Add(parametroidUsu);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void EliminarProducto(int id)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "DELETE FROM ProductoVendido where IdProducto = @idpro";
                var parametro2 = new SqlParameter();
                parametro2.ParameterName = "idpro";
                parametro2.SqlDbType = SqlDbType.BigInt;
                parametro2.Value = id;

                cmd2.Parameters.Add(parametro2);
                cmd2.ExecuteNonQuery();

                connection.Close();

                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Producto where id = @idpro";

                var parametro = new SqlParameter();
                parametro.ParameterName = "idpro";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static void ModificarProducto(Producto pro)
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
                cmd.CommandText = "UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta =  @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario where Id = @idpro)";

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "Idpro";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = pro.Id;

                var parametrodes = new SqlParameter();
                parametrodes.ParameterName = "Descripciones";
                parametrodes.SqlDbType = SqlDbType.VarChar;
                parametrodes.Value = pro.Descripciones;

                var parametrocos = new SqlParameter();
                parametrocos.ParameterName = "Costo";
                parametrocos.SqlDbType = SqlDbType.Money;
                parametrocos.Value = pro.Costo;

                var parametropreven = new SqlParameter();
                parametropreven.ParameterName = "PrecioVenta";
                parametropreven.SqlDbType = SqlDbType.Money;
                parametropreven.Value = pro.PrecioVenta;

                var parametrostock = new SqlParameter();
                parametrostock.ParameterName = "Stock";
                parametrostock.SqlDbType = SqlDbType.Int;
                parametrostock.Value = pro.Stock;

                var parametroidUsu = new SqlParameter();
                parametroidUsu.ParameterName = "IdUsuario";
                parametroidUsu.SqlDbType = SqlDbType.BigInt;
                parametroidUsu.Value = pro.IdUsuario;

                cmd.Parameters.Add(parametrodes);
                cmd.Parameters.Add(parametrocos);
                cmd.Parameters.Add(parametropreven);
                cmd.Parameters.Add(parametrostock);
                cmd.Parameters.Add(parametroidUsu);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}