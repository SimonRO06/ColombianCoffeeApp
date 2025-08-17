using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Users.Application.Services;
using ColombianCoffeeApp.src.Modules.Users.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Shared.Helpers;

namespace ColombianCoffeeApp.src.Modules.Users.UI
{
    public class UserMenu
    {
        private readonly IUserService _service;

        public UserMenu()
        {
            var db = DbContextFactory.Create();
            var repo = new UserRepository(db);
            _service = new UserService(repo);
        }

        public async Task Mostrar()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.Write("""
                ╔════════════════════════════════════════════╗
                ║      🙍 Gestión de Usuarios (CRUD) 📋      ║
                ╚════════════════════════════════════════════╝
                ║ 1.- Listar TODOS los Usuarios              ║
                ║ 2.- Crear Nuevo Usuario                    ║
                ║ 3.- Eliminar Usuario                       ║
                ║ 4.- Regresar al 'Menú Anterior' ↩          ║
                ╚════════════════════════════════════════════╝
                Seleccione la opción: 
                """);
                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        await Listar();
                        break;
                    case "2":
                        await Crear();
                        break;
                    case "3":
                        await Eliminar();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task Listar()
        {
            Console.Clear();
            var usuarios = await _service.ObtenerTodosAsync();

            Console.WriteLine("\n📋 LISTA DE USUARIOS:");
            if (!usuarios.Any())
            {
                Console.WriteLine("No hay usuarios registrados.");
            }
            else
            {
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"ID: {u.Id} | Usuario: {u.NombreUsuario} | Rol: {u.Rol}");
                }
            }
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private async Task Crear()
        {
            Console.Clear();
            Console.WriteLine("➕ CREAR NUEVO USUARIO");

            Console.Write("\nNombre de usuario: ");
            var nombre = Console.ReadLine();

            Console.Write("Contraseña: ");
            var contrasena = Console.ReadLine();

            Console.Write("Rol (Administrador/Usuario o 1/2): ");
            var rol = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contrasena) || string.IsNullOrWhiteSpace(rol))
            {
                Console.WriteLine("❌ Todos los campos son obligatorios. Intente de nuevo.");
            }
            else
            {
                try
                {
                    await _service.CrearUsuarioAsync(nombre, contrasena, rol);
                    Console.WriteLine("\n✅ Usuario creado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
            }

            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private async Task Eliminar()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR USUARIO ===\n");
            Console.Write("Ingrese el ID del usuario a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var ok = await _service.EliminarAsync(id);
                Console.WriteLine(ok ? "\n✅ Usuario eliminado." : "\n❌ No se encontró el usuario.");
            }
            else
            {
                Console.WriteLine("\n❌ ID inválido.");
            }
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}