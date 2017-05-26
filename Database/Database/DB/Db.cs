using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Db
    {
        //Esta var antes estaba definida localmente, ahora la convertimos a global o atributo
        private SqlConnection conexion = null;

        public void Conectar()
        {
            try
            {
                // Preparo la cadena de conexión a la Base de datos
                string cadenaConexion = @"Server=.\sqlexpress;
                                        Database=testdb;
                                        User Id=testuser;
                                        Password = !Curso@2017; ";

                // Creo la conexión
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                // Trato de abrir la conexión
                conexion.Open();


                //// Pregunto por el estado de la conexión
                //if (conexion.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("¡Conexión abierta con éxito!");
                //    // Cierro la conexión
                //    conexion.Close();
                //}

            }
            catch (Exception)
            {   //si la conexión es nula y el estado cerrarlo
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
            // Si tenemos error o no ésta parte del código siempre se va a ejecutar
            finally
            {
            //    if (conexion.State != ConnectionState.Closed)
            //    {
            //        conexion.Close();
            //        Console.WriteLine("¡Conexión cerrada con éxito!");
            //    }
            //    // Destruyo la conexión
            //    // Usamos el Dispose() En el proceso de destruccion tener tiempo de hacer otras acciones
            //    conexion.Dispose();
            //    conexion = null;
            }


        }

        public bool EstalaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public void Desconectar()
        {
            //this hace referencia a la propia clase, es decir, conexión es un atributo de la clase Db
            if(this.conexion != null)
            {
                if(this.conexion.State != ConnectionState.Closed)
                {
                    this.conexion.Close();
                }
            }
        }

        public List<Usuario> DameLosUsuarios()
        {
            //Usuario[]   usuarios = null;
            List<Usuario> usuarios = null;
            // Preparo la consulta SQL para obtener los usuarios
            string consultaSQL = "SELECT * FROM Users;";

            // Preparo un comando para ejecutar a la base de datos
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);

            // Recojo los datos (ExecuteReader: es la manera de ejecutarlo)
            SqlDataReader reader = comando.ExecuteReader();
            usuarios = new List<Usuario>();
            //Si hay filas para leer entonces devuelve algo

            //con Read accedo a una linea cada vez, se ejecuta tantas veces como lineas tenga
            while (reader.Read())
            {
                usuarios.Add(new Usuario()
                {
                    //pasar todos los datos de usuario a una lista
                    //Convertir a número el hiddenId
                    hiddenId = int.Parse(reader["hiddenId"].ToString()),
                    Id = reader["Id"].ToString(),
                    email = reader["email"].ToString(),
                    password = reader["password"].ToString(),
                    firstName = reader["firstName"].ToString(),
                    lastName = reader["lastName"].ToString(),
                    photoUrl = reader["photoUrl"].ToString(),
                    searchPreferences = reader["searchPreferences"].ToString(),
                    //Tres formas de convertir número a booleano
                    status = bool.Parse(reader["status"].ToString()),
                    deleted = (bool)reader["deleted"],
                    isAdmin = Convert.ToBoolean(reader["isAdmin"])
                });

            }

            // Devuelvo los datos
            return usuarios;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            // PREPARO LA CONSULTA SQL PARA INSERTAR AL NUEVO USUARIO
            string consultaSQL = @"INSERT INTO Users (
                                                email
                                               ,password
                                               ,firstName
                                               ,lastName
                                               ,photoUrl
                                               ,searchPreferences
                                               ,status
                                               ,deleted
                                               ,isAdmin
                                               )
                                         VALUES (";
            consultaSQL += "'" + usuario.email + "'";
            consultaSQL += ",'" + usuario.password + "'";
            consultaSQL += ",'" + usuario.firstName + "'";
            consultaSQL += ",'" + usuario.lastName + "'";
            consultaSQL += ",'" + usuario.photoUrl + "'";
            consultaSQL += ",'" + usuario.searchPreferences + "'";
            consultaSQL += "," + (usuario.status ? "1" : "0");
            consultaSQL += "," + (usuario.deleted ? "1" : "0");
            consultaSQL += "," + (usuario.isAdmin ? "1" : "0");
            consultaSQL += ");";

            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            // RECOJO LOS DATOS
            comando.ExecuteNonQuery();
        }

        public void ElminarUsuario(string email)
        {
            // PREPARO LA CONSULTA SQL PARA ELIMINAR AL NUEVO USUARIO
            string consultaSQL = @"DELETE FROM Users 
                                   WHERE email = '" + email + "';";

            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            // RECOJO LOS DATOS
            comando.ExecuteNonQuery();
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            // PREPARO LA CONSULTA SQL PARA INSERTAR AL NUEVO USUARIO
            string consultaSQL = @"UPDATE Users ";
            consultaSQL += "   SET password = '" + usuario.password + "'";
            consultaSQL += "      , firstName = '" + usuario.firstName + "'";
            consultaSQL += "      , lastName = '" + usuario.lastName + "'";
            consultaSQL += "      , photoUrl = '" + usuario.photoUrl + "'";
            consultaSQL += "      , searchPreferences = '" + usuario.searchPreferences + "'";
            consultaSQL += "      , status = " + (usuario.status ? "1" : "0");
            consultaSQL += "      , deleted = " + (usuario.deleted ? "1" : "0");
            consultaSQL += "      , isAdmin = " + (usuario.isAdmin ? "1" : "0");
            consultaSQL += " WHERE email = '" + usuario.email + "';";

            // PREPARO UN COMANDO PARA EJECUTAR A LA BASE DE DATOS
            SqlCommand comando = new SqlCommand(consultaSQL, conexion);
            // RECOJO LOS DATOS
            comando.ExecuteNonQuery();
        }
            
    }
}
