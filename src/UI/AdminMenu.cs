using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.UI;
using ColombianCoffeeApp.src.Modules.Varieties.UI;
using ColombianCoffeeApp.src.Services;
using ColombianCoffeeApp.src.Shared.Helpers;

namespace ColombianCoffeeApp.src.UI
{
    public class AdminMenu : IMenu
    {
        public async Task MostrarAsync()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.Write("""
                ╔════════════════════════════════════════╗
                ║        🔧 MENÚ ADMINISTRADOR 🔧        ║
                ╚════════════════════════════════════════╝
                ║ 1.- CRUD Variedades                    ║
                ║ 2.- CRUD Usuarios                      ║
                ║ 3.- Generar catálogo PDF               ║
                ║ 4.- Cerrar Sesión                      ║
                ╚════════════════════════════════════════╝
                Seleccione la opción: 
                """);

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        new VarietyMenu().Mostrar();
                        break;
                    case "2":
                        await new AdminUserMenu().MostrarAsync();
                        break;
                    case "3":
                        using (var db = DbContextFactory.Create())
                        {
                            var variedades = db.Variedades.ToList();
                            var pdfService = new PdfService();
                            pdfService.GenerarCatalogo(variedades, "catalogo.pdf");
                            Console.ReadKey();
                        }
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
    }
}