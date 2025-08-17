using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Users.Domain;

namespace ColombianCoffeeApp.src.UI
{
    public class MainMenu : IMenu
    {
         private readonly IUserService _usuarioService; // Servicio de usuarios inyectado

        public MainMenu(IUserService usuarioService) // Constructor que recibe el servicio de usuarios
        {
            _usuarioService = usuarioService; // Inyecta el servicio de usuarios
        }

        public async Task MostrarAsync()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.Write("""
                ╔════════════════════════════════════════════╗
                ║     ✨ BIENVENIDO A COLOMBIAN COFFEE ✨    ║
                ╚════════════════════════════════════════════╝
                ║ 1.- Iniciar Sesión                         ║
                ║ 2.- Crear Nueva Cuenta                     ║
                ║ 3.- Salir                                  ║
                ╚════════════════════════════════════════════╝
                Seleccione la opción: 
                """);

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        await IniciarSesionAsync();
                        break;
                    case "2":
                        await CrearCuentaAsync();
                        break;
                    case "3":
                        salir = true;
                        Console.WriteLine("👋 ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task IniciarSesionAsync()
        {
            Console.Clear();
            Console.WriteLine("🔐 Iniciar Sesión");
            Console.Write("\nUsuario: ");
            string usuario = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";

            var result = await _usuarioService.LoginAsync(usuario, contrasena); // Llama al servicio de usuarios para autenticar

            if (result == null)
            {
                Console.WriteLine("❌ Usuario o contraseña incorrectos.");
                Console.ReadKey();
                return;
            }

            IMenu menuRol = result.Rol == RolUsuario.Administrador
                ? new AdminMenu()
                : new AdminUserMenu(); // Selecciona el menú según el rol del usuario autenticado

            await menuRol.MostrarAsync(); // Muestra el menú correspondiente según el rol del usuario autenticado
        }

        private async Task CrearCuentaAsync()
        {
            Console.Clear();
            Console.WriteLine("📝 Crea una Nueva Cuenta");
            Console.Write("\nNuevo usuario: ");
            string usuario = Console.ReadLine() ?? "";
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine() ?? "";
            Console.Write("Rol (Administrador (1)/ Usuario (2)): ");
            string rol = Console.ReadLine() ?? "";

            await _usuarioService.CrearUsuarioAsync(usuario, contrasena, rol); // Llama al servicio de usuarios para crear una nueva cuenta
            Console.Write("✅ Usuario creado. Inicie sesión para continuar.");
            Console.ReadKey();
        }
    }
}