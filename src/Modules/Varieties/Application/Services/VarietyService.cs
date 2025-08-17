using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Enums;

namespace ColombianCoffeeApp.src.Modules.Varieties.Application.Services
{
    public class VarietyService : IVarietyService
    {
        private readonly IVarietyRepository _repositorio;

        public VarietyService(IVarietyRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void CrearVariedad(CoffeeVariety variedad)
        {
            if (string.IsNullOrWhiteSpace(variedad.NombreComun))
                throw new ArgumentException("El nombre común es obligatorio.");
            if (string.IsNullOrWhiteSpace(variedad.NombreCientifico))
                throw new ArgumentException("El nombre científico es obligatorio.");
            if (string.IsNullOrWhiteSpace(variedad.Descripcion))
                throw new ArgumentException("La descripción es obligatoria.");
            if (string.IsNullOrWhiteSpace(variedad.RutaImagen))
                throw new ArgumentException("La ruta de la imagen es obligatoria.");
            if (string.IsNullOrWhiteSpace(variedad.TiempoCosecha))
                throw new ArgumentException("El tiempo de cosecha es obligatorio.");
            if (string.IsNullOrWhiteSpace(variedad.TiempoMaduracion))
                throw new ArgumentException("El tiempo de maduración es obligatorio.");
            if (string.IsNullOrWhiteSpace(variedad.RecomendacionNutricion))
                throw new ArgumentException("La recomendación nutricional es obligatoria.");
            if (string.IsNullOrWhiteSpace(variedad.DensidadSiembra))
                throw new ArgumentException("La densidad de siembra es obligatoria.");
            if (string.IsNullOrWhiteSpace(variedad.Historia))
                throw new ArgumentException("La historia es obligatoria.");
            if (string.IsNullOrWhiteSpace(variedad.GrupoGenetico))
                throw new ArgumentException("El grupo genético es obligatorio.");
            if (string.IsNullOrWhiteSpace(variedad.Obtentor))
                throw new ArgumentException("El obtentor es obligatorio.");
            if (string.IsNullOrWhiteSpace(variedad.Familia))
                throw new ArgumentException("La familia es obligatoria.");
            if (variedad.AltitudOptima <= 0)
                throw new ArgumentException("La altitud óptima debe ser mayor a 0.");
            if (variedad.CalidadGrano <= 0)
                throw new ArgumentException("La calidad del grano debe ser mayor a 0.");
            if (!Enum.IsDefined(typeof(PorteVariedad), variedad.Porte))
                throw new ArgumentException("Porte inválido.");
            if (!Enum.IsDefined(typeof(TamanoGranoVariedad), variedad.TamanoGrano))
                throw new ArgumentException("Tamaño de grano inválido.");
            if (!Enum.IsDefined(typeof(RendimientoVariedad), variedad.Rendimiento))
                throw new ArgumentException("Rendimiento inválido.");
            if (!Enum.IsDefined(typeof(RoyaVariedad), variedad.ResistenciaRoya))
                throw new ArgumentException("Resistencia a la roya inválida.");
            if (!Enum.IsDefined(typeof(AntracnosisVariedad), variedad.ResistenciaAntracnosis))
                throw new ArgumentException("Resistencia a la antracnosis inválida.");
            if (!Enum.IsDefined(typeof(NematodosVariedad), variedad.ResistenciaNematodos))
                throw new ArgumentException("Resistencia a nematodos inválida.");

            _repositorio.Agregar(variedad);
        }


        public List<CoffeeVariety> ObtenerTodas()
        {
            return _repositorio.ObtenerTodas();
        }

        public CoffeeVariety? ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        public void ActualizarVariedad(CoffeeVariety variedad)
        {
            if (variedad.Id <= 0)
                throw new ArgumentException("ID inválido para actualizar");

            _repositorio.Actualizar(variedad);
        }

        public bool EliminarVariedad(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido para eliminar");

            return _repositorio.Eliminar(id);
        }

        public List<CoffeeVariety> FiltrarPorAtributo(string atributo, string valor)
        {
            if (string.IsNullOrWhiteSpace(atributo) || string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("El atributo y el valor no pueden estar vacíos");

            switch (atributo.Trim().ToLower())
            {
                case "porte":
                    return _repositorio.FiltrarVariedades(porte: valor);
                case "tamanograno":
                    return _repositorio.FiltrarVariedades(tamanoGrano: valor);
                case "rendimiento":
                    return _repositorio.FiltrarVariedades(rendimiento: valor);
                case "calidadgrano":
                    return _repositorio.FiltrarVariedades(calidad: valor);
                case "resistenciaroya":
                    return _repositorio.FiltrarVariedades(resistenciaTipo: "roya", resistenciaValor: valor);
                case "resistenciaantracnosis":
                    return _repositorio.FiltrarVariedades(resistenciaTipo: "antracnosis", resistenciaValor: valor);
                case "resistencianematodos":
                    return _repositorio.FiltrarVariedades(resistenciaTipo: "nematodos", resistenciaValor: valor);
                default:
                    return new List<CoffeeVariety>();
            }
        }

        public IEnumerable<CoffeeVariety> FiltrarPorAtributos(List<(string atributo, string valor)> filtros)
        {
            var lista = _repositorio.ObtenerTodas();

            foreach (var (atributo, valor) in filtros)
            {
                var prop = typeof(CoffeeVariety).GetProperty(atributo);
                if (prop == null)
                    throw new ArgumentException($"El atributo '{atributo}' no existe.");

                lista = lista
                    .Where(v => 
                        {
                            var propValue = prop.GetValue(v);
                            return propValue?.ToString()?.Equals(valor, StringComparison.OrdinalIgnoreCase) == true;
                        }
                    )
                    .ToList();
            }

            return lista;
        }

        public List<CoffeeVariety> Sugerencias(string porte, string resistenciaRoya)
        {
            return _repositorio.FiltrarVariedades(
                porte: porte,
                resistenciaTipo: "roya",
                resistenciaValor: resistenciaRoya
            );
        }

    }
}