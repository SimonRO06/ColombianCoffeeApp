using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace ColombianCoffeeApp.src.Shared.Helpers
{
    public class MySqlVersionRessolver
    {
        public static Version DetectVersion(string connectionString)
        {
            using var conn = new MySqlConnection(connectionString); // Crea una nueva conexión a la base de datos MySQL
            conn.Open(); // Abre la conexión para obtener información sobre la versión del servidor
            var raw = conn.ServerVersion; // Obtiene la versión del servidor MySQL en formato de cadena
            var clean = raw.Split('-')[0]; // Limpia la cadena de versión, eliminando cualquier información adicional después del guion
            return Version.Parse(clean); // Convierte la cadena de versión limpia a un objeto Version
        }
    }
}