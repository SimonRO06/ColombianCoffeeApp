using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ColombianCoffeeApp.src.Modules.Users.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;

namespace ColombianCoffeeApp.src.Shared.Context
{
    public class AppDbContext : DbContext // Clase que representa el contexto de la base de datos para Entity Framework Core
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Constructor que recibe las opciones de configuración
        {
        }

        public DbSet<User> Users => Set<User>(); // DbSet para la entidad User, permite realizar operaciones CRUD sobre la tabla "usuario"
        public DbSet<CoffeeVariety> Variedades => Set<CoffeeVariety>(); // DbSet para la entidad CoffeeVariety, permite realizar operaciones CRUD sobre la tabla "variedad"

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("usuario"); // Configura el nombre de la tabla para la entidad User
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Aplica todas las configuraciones de entidades desde el ensamblado actual
        }
    }
}