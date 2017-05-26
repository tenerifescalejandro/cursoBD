using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectando a la base de datos");
            Db database = new Db();
            database.Conectar();

            if (database.EstalaConexionAbierta())
            {
                Usuario nuevoUsuario = new Usuario()
                {
                    //hiddenId = 0,
                    //id = "",
                    firstName = "MANOLO",
                    lastName = "EL DEL BOMBO",
                    email = "kk3@kk.com",
                    password = "123456",
                    photoUrl = "",
                    searchPreferences = "",
                    status = false,
                    deleted = false,
                    isAdmin = false,
                };
                database.InsertarUsuario(nuevoUsuario);
                Console.WriteLine("Usuario insertado, pulsa una tecla para continuar...");
                Console.ReadKey();

                nuevoUsuario.firstName += " modificado!!";
                database.ActualizarUsuario(nuevoUsuario);
                Console.WriteLine("Usuario actualizado, pulsa una tecla para continuar...");
                Console.ReadKey();

                database.ElminarUsuario("kk3@kk.com");
                Console.WriteLine("Usuario eliminado, pulsa una tecla para continuar...");

                List<Usuario> listaUsuarios = database.DameLosUsuarios();
                // Esta instrucción se hará tantan veces como elementos haya en la lista
                listaUsuarios.ForEach(usuario =>
                {
                    Console.WriteLine(
                            " hiddenId: " + usuario.hiddenId
                            +
                            " id: " + usuario.Id
                            +
                            " email: " + usuario.email
                            +
                            " password: " + usuario.password
                            +
                            " nombre: " + usuario.firstName
                            +
                            " Apellidos: " + usuario.lastName
                            +
                            " photoUrl: " + usuario.photoUrl
                            );
                });
            }
            database.Desconectar();
            database = null;
            Console.ReadKey();
        }
    }
}