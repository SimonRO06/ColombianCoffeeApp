using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Varieties.Application.Interfaces
{
    public interface IVarietyRepository
    {
        void Agregar(CoffeeVariety variedad); // Agrega una nueva variedad de café al repositorio
        List<CoffeeVariety> ObtenerTodas(); // Obtiene todas las variedades de café
        CoffeeVariety? ObtenerPorId(int id); // Obtiene una variedad de café por su ID
        void Actualizar(CoffeeVariety variedad); // Actualiza una variedad de café existente en el repositorio
        bool Eliminar(int id); // Elimina una variedad de café por su ID
        List<CoffeeVariety> FiltrarVariedades(
            string? porte = null,
            string? tamanoGrano = null,
            int? altitudMin = null,
            int? altitudMax = null,
            string? rendimiento = null,
            string? calidad = null,
            string? resistenciaTipo = null,
            string? resistenciaValor = null
        ); // Filtra las variedades de café según los atributos proporcionados
    }
}