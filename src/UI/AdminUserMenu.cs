using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.UI;
using ColombianCoffeeApp.src.Shared.Helpers;
using ColombianCoffeeApp.src.Modules.Varieties.Application;
using ColombianCoffeeApp.src.Services;

namespace ColombianCoffeeApp.src.UI
{
    public class AdminUserMenu : IMenu
    {
        public async Task MostrarAsync()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.Write("""
                ╔══════════════════════════════════════╗
                ║          👤 MENÚ USUARIO 👤          ║
                ╚══════════════════════════════════════╝
                ║ 1.- Explorar Variedades              ║
                ║ 2.- Generar catálogo PDF             ║
                ║ 3.- Cerrar Sesión                    ║
                ╚══════════════════════════════════════╝
                Seleccione la opción: 
                """);

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        using (var db = DbContextFactory.Create())
                        {
                            var repoVariedades = new ColombianCoffeeApp.src.Modules.Varieties.Infrastructure.Repositories.VarietyRepository(db);
                            var serviceVariedades = new ColombianCoffeeApp.src.Modules.Varieties.Application.Services.VarietyService(repoVariedades);
                            await Task.Run(() => new ExplorationMenu(serviceVariedades).Mostrar());
                        }
                        break;
                    case "2":
                        using (var db = DbContextFactory.Create())
                        {
                            var variedades = await Task.Run(() => db.Variedades.ToList());
                            var pdfService = new PdfService();
                            pdfService.GenerarCatalogo(variedades, "catalogo.pdf");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
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