using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Varieties.Application.Interfaces
{
    public interface IVarietyService
    {
        void CrearVariedad(CoffeeVariety variedad);
        List<CoffeeVariety> ObtenerTodas();
        CoffeeVariety? ObtenerPorId(int id);
        void ActualizarVariedad(CoffeeVariety variedad);
        bool EliminarVariedad(int id);
        List<CoffeeVariety> FiltrarPorAtributo(string atributo, string valor);
        IEnumerable<CoffeeVariety> FiltrarPorAtributos(List<(string atributo, string valor)> filtros);
        List<CoffeeVariety> Sugerencias(string porte, string resistenciaRoya);
    }
}