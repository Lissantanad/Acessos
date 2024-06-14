using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_usuario
    {

        public bool VerificarUsuario(string nombreUsuario, decimal contraseña)
        {
            try
            {
                conexion conexion = new conexion();
                using (var connection = conexion.AbrirConexion())
                {

                    Console.WriteLine("Estado de la conexión antes de abrir: " + connection.State.ToString());


                    connection.open();
                    Console.WriteLine("Conexión abierta exitosamente.");

                    string query = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario = @nombreUsuario AND contraseña = CAST(@contraseña AS numeric)";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        command.Parameters.AddWithValue("@contraseña", contraseña);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al cargar usuario: " + ex.Message);
                return false;
            }

        }
    }
}
