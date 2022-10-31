using static WebApplication1.Controllers.UsuarioController;
using System.Data.SqlClient;
using WebApplication1.Models;
using System.Data;

namespace WebApplication1.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> DevolverUsuarios()
        {
            var listaUsuarios = new List<Usuario>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM usuario";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader2.GetValue(0));
                    usuario.Nombre = reader2.GetValue(1).ToString();
                    usuario.Apellido = reader2.GetValue(2).ToString();
                    usuario.NombreUsuario = reader2.GetValue(3).ToString();
                    usuario.Contraseña = reader2.GetValue(4).ToString();
                    usuario.Mail = reader2.GetValue(5).ToString();

                    listaUsuarios.Add(usuario);

                }
                reader2.Close();
                connection.Close();

            }
            return listaUsuarios;
        }

        public static void EliminarUsuario(int id)
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
                cmd.CommandText = "DELETE FROM usuario where id = @idusu";

                var parametro = new SqlParameter();
                parametro.ParameterName = "idusu";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void AgregarUsuario(Usuario usu)
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
                cmd.CommandText = "Insert into Usuario(Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail)" + 
                    " Values (@idUsu, @nombreUsu, @apellidoUsu, @nombreUsuarioUsu, @contraseñaUsu, @mailUsu)";

                var parametroNombre = new SqlParameter();
                parametroNombre.ParameterName = "nombreUsu";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                parametroNombre.Value = usu.Nombre;

                var parametroApe = new SqlParameter();
                parametroApe.ParameterName = "apellidoUsu";
                parametroApe.SqlDbType = SqlDbType.VarChar;
                parametroApe.Value = usu.Apellido;

                var parametronomusu = new SqlParameter();
                parametronomusu.ParameterName = "nombreUsuarioUsu";
                parametronomusu.SqlDbType = SqlDbType.VarChar;
                parametronomusu.Value = usu.NombreUsuario;

                var parametrocontra = new SqlParameter();
                parametrocontra.ParameterName = "contraseñaUsu";
                parametrocontra.SqlDbType = SqlDbType.VarChar;
                parametrocontra.Value = usu.Contraseña;

                var parametromail = new SqlParameter();
                parametromail.ParameterName = "mailUsu";
                parametromail.SqlDbType = SqlDbType.VarChar;
                parametromail.Value = usu.Mail;

                cmd.Parameters.Add(parametroNombre);
                cmd.Parameters.Add(parametroApe);
                cmd.Parameters.Add(parametronomusu);
                cmd.Parameters.Add(parametrocontra);
                cmd.Parameters.Add(parametromail);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarUsuario(Usuario usu)
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
                cmd.CommandText = "UPDATE Usuario SET Nombre = @nombreUsu, Apellido = @apellidoUsu, NombreUsuario =  @nombreUsuarioUsu, Contraseña = @contraseñaUsu, Mail = @mailUsu where Id = @idusu";

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "idusu";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = usu.Id;

                var parametroNombre = new SqlParameter();
                parametroNombre.ParameterName = "nombreUsu";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                parametroNombre.Value = usu.Nombre;

                var parametroApe = new SqlParameter();
                parametroApe.ParameterName = "apellidoUsu";
                parametroApe.SqlDbType = SqlDbType.VarChar;
                parametroApe.Value = usu.Apellido;

                var parametronomusu = new SqlParameter();
                parametronomusu.ParameterName = "nombreUsuarioUsu";
                parametronomusu.SqlDbType = SqlDbType.VarChar;
                parametronomusu.Value = usu.NombreUsuario;

                var parametrocontra = new SqlParameter();
                parametrocontra.ParameterName = "contraseñaUsu";
                parametrocontra.SqlDbType = SqlDbType.VarChar;
                parametrocontra.Value = usu.Contraseña;

                var parametromail = new SqlParameter();
                parametromail.ParameterName = "mailUsu";
                parametromail.SqlDbType = SqlDbType.VarChar;
                parametromail.Value = usu.Mail;

                cmd.Parameters.Add(parametroid);
                cmd.Parameters.Add(parametroNombre);
                cmd.Parameters.Add(parametroApe);
                cmd.Parameters.Add(parametronomusu);
                cmd.Parameters.Add(parametrocontra);
                cmd.Parameters.Add(parametromail);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Usuario InicioSesion(string nomUsuario, string pass)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                var comando = new SqlCommand("select * from Usuario where @NomUsu = NombreUsuario and Contraseña = @Contraseña", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "NomUsu";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nomUsuario;

                comando.Parameters.Add(parametro);

                var parametro1 = new SqlParameter();

                parametro1.ParameterName = "Contraseña";
                parametro1.SqlDbType = SqlDbType.VarChar;
                parametro1.Value = pass;

                comando.Parameters.Add(parametro1);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contraseña = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();
                }
                reader.Close();
            }
            return usuario;
        }

        public static Usuario TraerUsuario(string nombre)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-O2006PP";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                var comando = new SqlCommand("select * from Usuario where @NomUsu = Nombre", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "NomUsu";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = nombre;

                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contraseña = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();
                }
                reader.Close();
            }
            return usuario;
        }
    }
}