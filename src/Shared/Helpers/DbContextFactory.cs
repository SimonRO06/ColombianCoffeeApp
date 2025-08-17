using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Shared.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ColombianCoffeeApp.src.Shared.Helpers
{
    public class DbContextFactory // Clase encargada de crear instancias de AppDbContext
    {public static AppDbContext Create() // Método estático que crea y configura el contexto de base de datos
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
            string? connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION") // Obtiene la cadena de conexión desde la variable de entorno "MYSQL_CONNECTION"
                                ?? config.GetConnectionString("DefaultConnection"); // o, si no existe, la obtiene del archivo de configuración

            if (string.IsNullOrWhiteSpace(connectionString)) // Si no encuentra una cadena de conexión válida, lanza una excepción
                throw new InvalidOperationException("No se encontró una cadena de conexión válida.");
            var detectedVersion = MySqlVersionRessolver.DetectVersion(connectionString); // Detecta la versión de MySQL que está usando la cadena de conexión
            var minVersion = new Version(8, 0, 0); // Define la versión mínima requerida de MySQL
            if (detectedVersion < minVersion) // Si la versión detectada es menor que la mínima requerida, lanza una excepción
                throw new NotSupportedException($"Versión de MySQL no soportada: {detectedVersion}. Requiere {minVersion} o superior.");

            var options = new DbContextOptionsBuilder<AppDbContext>() // Configura las opciones para el AppDbContext con la conexión y la versión detectada de MySQL
                .UseMySql(connectionString, new MySqlServerVersion(detectedVersion))
                .Options;
            return new AppDbContext(options); // Devuelve una nueva instancia del contexto configurado
        }
    }
}