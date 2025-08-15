using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Application.Services;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Varieties.Infrastructure.Repositories;

namespace ColombianCoffeeApp.src.Modules.Varieties.UI
{
    public class ExplorationMenu
    {
        private readonly VarietyService _service;

        public ExplorationMenu (VarietyService service)
        {
            _service = service;
        }

        public void Mostrar()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("""
                ╔════════════════════════════════════════════╗
                ║     👀 EXPLORAR VARIEDADES DE CAFÉ 👀      ║
                ╚════════════════════════════════════════════╝
                ║ 1.- Listar Todas las Variables             ║
                ║ 2.- Ver Ficha Técnica (ID)                 ║
                ║ 3.- Filtrar por Atributo                   ║
                ║ 4.- Volver a 'Menú Principal' ↩            ║
                ╚════════════════════════════════════════════╝
                Seleccione la opción: 
                """
                );
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarTodas();
                        break;
                    case "2":
                        VerFichaPorId();
                        break;
                    case "3":
                        FiltrarPorAtributo();
                        break;
                    case "4":
                        return;
                    default:
                        Console.Write("❌ Opción inválida. Presione una tecla...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ListarTodas()
        {
            Console.Clear();
            var variedades = _service.ObtenerTodas();

            if (!variedades.Any())
            {
                Console.WriteLine("No hay variedades registradas.");
            }
            else
            {
                foreach (var v in variedades)
                {
                    Console.WriteLine($"{v.Id} - {v.NombreComun} ({v.NombreCientifico})");
                }
            }

            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void VerFichaPorId()
        {
            Console.Write("\nIngrese el ID de la variedad: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var variedad = _service.ObtenerPorId(id);
                if (variedad != null)
                {
                    MostrarFichaTecnica(variedad);
                }
                else
                {
                    Console.WriteLine("⚠️ No se encontró la variedad.");
                }
            }
            else
            {
                Console.WriteLine("❌ ID inválido.");
            }
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        private void FiltrarPorAtributo()
        {
            var filtros = new List<(string atributo, string valor)>();

            bool agregarOtro = true;
            while (agregarOtro)
            {
                Console.Write("\nIngrese el nombre del atributo (ej: Porte, TamanoGrano): ");
                string? atributo = Console.ReadLine();
                Console.Write("Ingrese el valor a buscar: ");
                string? valor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(atributo) || string.IsNullOrWhiteSpace(valor))
                {
                    Console.WriteLine("⚠️ El atributo y el valor no pueden estar vacíos.");
                }
                else
                {
                    filtros.Add((atributo, valor));
                }

                Console.Write("¿Desea agregar otro filtro? (s/n): ");
                string respuesta = Console.ReadLine()?.Trim().ToLower() ?? "";
                agregarOtro = (respuesta == "s");
            }

            try
            {
                var resultados = _service.FiltrarPorAtributos(filtros);

                if (!resultados.Any())
                {
                    Console.WriteLine("❌ No se encontraron variedades con esos criterios.");
                }
                else
                {
                    Console.WriteLine("\n📋 Resultados:");
                    foreach (var v in resultados)
                    {
                        Console.WriteLine($"{v.Id} - {v.NombreComun} ({v.NombreCientifico})");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }


        private void MostrarFichaTecnica(CoffeeVariety v)
        {
            Console.Clear();
            Console.WriteLine($"╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"                                            Ficha Técnica de {v.NombreComun}                            ");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"Nombre Científico         ║ { v.NombreCientifico}");
            Console.WriteLine($"Descripción               ║ { v.Descripcion}");
            Console.WriteLine($"Porte                     ║ { v.Porte}");
            Console.WriteLine($"Tamaño del Grano          ║ { v.TamanoGrano}");
            Console.WriteLine($"Altitud Óptima            ║ { v.AltitudOptima} msnm");
            Console.WriteLine($"Rendimiento               ║ { v.Rendimiento}");
            Console.WriteLine($"Calidad del Grano         ║ { v.CalidadGrano}");
            Console.WriteLine($"Resistencia a Roya        ║ { v.ResistenciaRoya}");
            Console.WriteLine($"Resistencia a Antracnosis ║ { v.ResistenciaAntracnosis}");
            Console.WriteLine($"Resistencia a Nematodos   ║ { v.ResistenciaNematodos}");
            Console.WriteLine($"Tiempo de Cosecha         ║ { v.TiempoCosecha}");
            Console.WriteLine($"Tiempo de Maduración      ║ { v.TiempoMaduracion}");
            Console.WriteLine($"Recomendación Nutricional ║ { v.RecomendacionNutricion}");
            Console.WriteLine($"Densidad de Siembra       ║ { v.DensidadSiembra}");
            Console.WriteLine($"Historia                  ║ { v.Historia}");
            Console.WriteLine($"Grupo Genético            ║ { v.GrupoGenetico}");
            Console.WriteLine($"Obtentor                  ║ { v.Obtentor}");
            Console.WriteLine($"Familia                   ║ { v.Familia}");
            Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
    }
}