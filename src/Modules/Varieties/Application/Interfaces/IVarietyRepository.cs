using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Varieties.Application.Interfaces
{
    public interface IVarietyRepository
    {
        void Agregar(CoffeeVariety variedad);
        List<CoffeeVariety> ObtenerTodas();
        CoffeeVariety? ObtenerPorId(int id);
        void Actualizar(CoffeeVariety variedad);
        bool Eliminar(int id);
        List<CoffeeVariety> FiltrarVariedades(
            string? porte = null,
            string? tamanoGrano = null,
            int? altitudMin = null,
            int? altitudMax = null,
            string? rendimiento = null,
            string? calidad = null,
            string? resistenciaTipo = null,
            string? resistenciaValor = null
        );
    }
}