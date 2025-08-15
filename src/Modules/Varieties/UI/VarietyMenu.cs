using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Application.Services;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Enums;
using ColombianCoffeeApp.src.Modules.Varieties.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Shared.Helpers;

namespace ColombianCoffeeApp.src.Modules.Varieties.UI
{
    public class VarietyMenu
    {
        private readonly VarietyService _service;

        public VarietyMenu()
        {
            var db = DbContextFactory.Create();
            var repo = new VarietyRepository(db);
            _service = new VarietyService(repo);
        }

        public void Mostrar()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.Write("""
                ╔════════════════════════════════════════════╗
                ║         📋 GESTIÓN DE VARIEDADES 📋       ║
                ╚════════════════════════════════════════════╝
                ║ 1.- Listar Todas las Variedades            ║
                ║ 2.- Añadir Nueva Variedad                  ║
                ║ 3.- Editar Variedad Existente              ║
                ║ 4.- Eliminar Variedad                      ║
                ║ 5.- Regresar al 'Menú Anterior' ↩          ║
                ╚════════════════════════════════════════════╝
                Seleccione la opción: 
                """
                );
                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        ListarVariedades();
                        break;
                    case "2":
                        CrearVariedad();
                        break;
                    case "3":
                        EditarVariedad();
                        break;
                    case "4":
                        EliminarVariedad();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("❌ Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ListarVariedades()
        {
            Console.Clear();
            var variedades = _service.ObtenerTodas();
            Console.WriteLine("\n📋 LISTA DE VARIEDADES:");
            if (!variedades.Any())
            {
                Console.WriteLine("No hay variedades registradas.");
            }
            else
            {
                foreach (var v in variedades)
                {
                    Console.WriteLine($"ID: {v.Id} | {v.NombreComun} - {v.NombreCientifico}");
                }
            }
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void CrearVariedad()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR NUEVA VARIEDAD ===");
            var variedad = new CoffeeVariety();

            Console.Write("Nombre común: ");
            variedad.NombreComun = Console.ReadLine();

            Console.Write("Nombre científico: ");
            variedad.NombreCientifico = Console.ReadLine();

            Console.Write("Descripción: ");
            variedad.Descripcion = Console.ReadLine();

            Console.Write("Ruta imagen: ");
            variedad.RutaImagen = Console.ReadLine();

            variedad.Porte = LeerEnum<PorteVariedad>("Porte (Alto/Medio/Bajo)");
            variedad.TamanoGrano = LeerEnum<TamanoGranoVariedad>("Tamaño grano (Pequeño/Medio/Grande)");

            Console.Write("Altitud óptima (número): ");
            if (!int.TryParse(Console.ReadLine(), out int altitudOptima))
            {
                Console.Write("⚠️ Valor inválido para altitud óptima. Presione una tecla...");
                Console.ReadKey();
                return;
            }
            variedad.AltitudOptima = altitudOptima;

            variedad.Rendimiento = LeerEnum<RendimientoVariedad>("Rendimiento (Bajo/Medio/Alto)");

            Console.Write("Calidad del grano (número): ");
            if (!int.TryParse(Console.ReadLine(), out int calidadGrano))
            {
                Console.Write("⚠️ Valor inválido para calidad del grano. Presione una tecla...");
                Console.ReadKey();
                return;
            }
            variedad.CalidadGrano = calidadGrano;

            variedad.ResistenciaRoya = LeerEnum<RoyaVariedad>("Resistencia Roya (Susceptible/Tolerante/Resistente)");
            variedad.ResistenciaAntracnosis = LeerEnum<AntracnosisVariedad>("Resistencia Antracnosis (Susceptible/Tolerante/Resistente)");
            variedad.ResistenciaNematodos = LeerEnum<NematodosVariedad>("Resistencia Nematodos (Susceptible/Tolerante/Resistente)");

            Console.Write("Tiempo de cosecha: ");
            variedad.TiempoCosecha = Console.ReadLine();

            Console.Write("Tiempo de maduración: ");
            variedad.TiempoMaduracion = Console.ReadLine();

            Console.Write("Recomendación nutricional: ");
            variedad.RecomendacionNutricion = Console.ReadLine();

            Console.Write("Densidad de siembra: ");
            variedad.DensidadSiembra = Console.ReadLine();

            Console.Write("Historia: ");
            variedad.Historia = Console.ReadLine();

            Console.Write("Grupo genético: ");
            variedad.GrupoGenetico = Console.ReadLine();

            Console.Write("Obtentor: ");
            variedad.Obtentor = Console.ReadLine();

            Console.Write("Familia: ");
            variedad.Familia = Console.ReadLine();

            try
            {
                _service.CrearVariedad(variedad);
                Console.Write("\n✅ Variedad creada con éxito. Presione una tecla...");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n⚠️ Error: {ex.Message}");
            }
            Console.ReadKey();
        }

        private void EditarVariedad()
        {
            Console.Clear();
            Console.WriteLine("=== EDITAR VARIEDAD ===");
            Console.Write("Ingrese el ID de la variedad a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ ID inválido.");
                Console.ReadKey();
                return;
            }

            var variedad = _service.ObtenerPorId(id);
            if (variedad == null)
            {
                Console.WriteLine("⚠️ No se encontró la variedad.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Editando: {variedad.NombreComun}");
            Console.Write("Nuevo nombre común (enter para no cambiar): ");
            var nuevoValor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoValor)) variedad.NombreComun = nuevoValor;

            Console.Write("Nuevo nombre científico: ");
            nuevoValor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoValor)) variedad.NombreCientifico = nuevoValor;

            Console.Write("Nueva descripción: ");
            nuevoValor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoValor)) variedad.Descripcion = nuevoValor;

            _service.ActualizarVariedad(variedad);
            Console.WriteLine("✅ Variedad actualizada con éxito.");
            Console.ReadKey();
        }

        private void EliminarVariedad()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR VARIEDAD ===");
            Console.Write("Ingrese el ID de la variedad a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ ID inválido.");
                Console.ReadKey();
                return;
            }

            _service.EliminarVariedad(id);
            Console.WriteLine("✅ Variedad eliminada con éxito.");
            Console.ReadKey();
        }
        
        private T LeerEnum<T>(string mensaje) where T : struct
        {
            while (true)
            {
                Console.Write($"{mensaje}: ");
                var input = Console.ReadLine();
                if (Enum.TryParse<T>(input, true, out var valor))
                    return valor;

                Console.WriteLine("❌ Valor inválido. Intente de nuevo.");
            }
        }
    }
}