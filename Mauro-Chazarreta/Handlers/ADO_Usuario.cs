﻿using Mauro_Chazarreta.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mauro_Chazarreta.Handlers
{
    internal class ADO_Usuario
    {
        // A_ Metodo para traer un usuario por su nombre de usuario de la lista de usuarios
        public List<Usuario> GetUsuarioByNombreUsuario()
        {
            var listaProductos = new List<Usuario>();

            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "DESKTOP-O2006PP";
            connectionStringBuilder.InitialCatalog = "SistemaGestion";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                var comando = new SqlCommand("select * from Usuario where NombreUsuario = @NomUsu", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "NomUsu";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = "tcasazza";

                comando.Parameters.Add(parametro);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contrasena = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();

                    listaProductos.Add(usuario);
                }

                Console.WriteLine("-----Usuario-----");
                foreach (var usuario in listaProductos)
                {
                    Console.WriteLine("*Id = " + usuario.Id);
                    Console.WriteLine("*Nombre = " + usuario.Nombre);
                    Console.WriteLine("*Apellido = " + usuario.Apellido);
                    Console.WriteLine("*NombreUsuario = " + usuario.NombreUsuario);
                    Console.WriteLine("*Contraseña = " + usuario.Contrasena);
                    Console.WriteLine("*Mail = " + usuario.Mail);

                    Console.WriteLine("________________");
                }
                reader.Close();
            }
            return new List<Usuario>();
        }

        // E_ Metodo para iniciar sesion
        public List<Usuario> GetUsuarioByInicioSesion()
        {
            var listaProductos = new List<Usuario>();

            SqlConnectionStringBuilder connectionStringBuilder = new();
            connectionStringBuilder.DataSource = "DESKTOP-O2006PP";
            connectionStringBuilder.InitialCatalog = "SistemaGestion";
            connectionStringBuilder.IntegratedSecurity = true;
            var cs = connectionStringBuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                var comando = new SqlCommand("select * from Usuario where @NomUsu = NombreUsuario and Contraseña = @Contraseña", connection);

                var parametro = new SqlParameter();

                parametro.ParameterName = "NomUsu";
                parametro.SqlDbType = SqlDbType.VarChar;
                parametro.Value = "tcasazza";

                comando.Parameters.Add(parametro);

                var parametro1 = new SqlParameter();

                parametro1.ParameterName = "Contraseña";
                parametro1.SqlDbType = SqlDbType.VarChar;
                parametro1.Value = "SoyTobiasCasazza";

                comando.Parameters.Add(parametro1);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contrasena = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();

                    listaProductos.Add(usuario);
                }

                Console.WriteLine("-----Usuario-----");
                foreach (var usuario in listaProductos)
                {
                    Console.WriteLine("*Id = " + usuario.Id);
                    Console.WriteLine("*Nombre = " + usuario.Nombre);
                    Console.WriteLine("*Apellido = " + usuario.Apellido);
                    Console.WriteLine("*NombreUsuario = " + usuario.NombreUsuario);
                    Console.WriteLine("*Contraseña = " + usuario.Contrasena);
                    Console.WriteLine("*Mail = " + usuario.Mail);

                    Console.WriteLine("________________");
                }
                reader.Close();
            }
            return new List<Usuario>();
        }
    }
}