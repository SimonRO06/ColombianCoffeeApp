using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ColombianCoffeeApp.src.Shared.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "server=127.0.0.1;database=ColombianCoffeeApp;user=root;password=Fabioandres2007;"; // Ajusta la cadena de conexión según tu configuración
            
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0))); // Ajusta la versión de MySQL según tu configuración
            
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}