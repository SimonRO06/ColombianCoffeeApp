using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using ColombianCoffeeApp.src.Shared.Context;

namespace ColombianCoffeeApp.src.Modules.Varieties.Infrastructure.Repositories
{
    public class VarietyRepository : IVarietyRepository
    {
        private readonly AppDbContext _context;

        public VarietyRepository (AppDbContext context)
        {
            _context = context; // Inicializa el contexto de la base de datos
        }

        public void Agregar(CoffeeVariety variedad)
        {
            _context.Variedades.Add(variedad); // Agrega una nueva variedad al contexto
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }

        public List<CoffeeVariety> ObtenerTodas()
        {
            return _context.Variedades.ToList(); // Obtiene todas las variedades de café
        }

        public CoffeeVariety? ObtenerPorId(int id)
        {
            return _context.Variedades.FirstOrDefault(v => v.Id == id);
        }

        public void Actualizar(CoffeeVariety variedad)
        {
            _context.Variedades.Update(variedad); // Actualiza una variedad existente en el contexto
            _context.SaveChanges();
        }

        public bool Eliminar(int id)
        {
            var variedad = _context.Variedades.FirstOrDefault(v => v.Id == id); // Busca en la tabla Variedades la primera coincidencia con el Id dado, o null si no existe
            if (variedad == null)
                return false;

            _context.Variedades.Remove(variedad); // Elimina la variedad del contexto
            _context.SaveChanges();
            return true;
        }

        public List<CoffeeVariety> FiltrarVariedades(
            string? porte = null,
            string? tamanoGrano = null,
            int? altitudMin = null,
            int? altitudMax = null,
            string? rendimiento = null,
            string? calidad = null,
            string? resistenciaTipo = null,
            string? resistenciaValor = null)
        {
            var query = _context.Variedades.AsQueryable(); // Crea una consulta que se puede modificar

            if (!string.IsNullOrWhiteSpace(porte))
                query = query.Where(v => v.Porte.ToString().ToLower() == porte.ToLower());

            if (!string.IsNullOrWhiteSpace(tamanoGrano))
                query = query.Where(v => v.TamanoGrano.ToString().ToLower() == tamanoGrano.ToLower());

            if (altitudMin.HasValue)
                query = query.Where(v => v.AltitudOptima >= altitudMin.Value);

            if (altitudMax.HasValue)
                query = query.Where(v => v.AltitudOptima <= altitudMax.Value);

            if (!string.IsNullOrWhiteSpace(rendimiento))
                query = query.Where(v => v.Rendimiento.ToString().ToLower() == rendimiento.ToLower());

            if (!string.IsNullOrWhiteSpace(calidad))
                query = query.Where(v => v.CalidadGrano.ToString().ToLower() == calidad.ToLower());

            if (!string.IsNullOrWhiteSpace(resistenciaValor))
            {
                var val = resistenciaValor.ToLower();

                if (string.IsNullOrWhiteSpace(resistenciaTipo))
                {
                    query = query.Where(v =>
                        v.ResistenciaRoya.ToString().ToLower() == val ||
                        v.ResistenciaAntracnosis.ToString().ToLower() == val ||
                        v.ResistenciaNematodos.ToString().ToLower() == val
                    );
                }
                else
                {
                    switch (resistenciaTipo.Trim().ToLower())
                    {
                        case "roya":
                            query = query.Where(v => v.ResistenciaRoya.ToString().ToLower() == val);
                            break;
                        case "antracnosis":
                            query = query.Where(v => v.ResistenciaAntracnosis.ToString().ToLower() == val);
                            break;
                        case "nematodos":
                            query = query.Where(v => v.ResistenciaNematodos.ToString().ToLower() == val);
                            break;
                        default: // Si no coincide con ningún tipo, filtra en todas
                            query = query.Where(v =>
                                v.ResistenciaRoya.ToString().ToLower() == val ||
                                v.ResistenciaAntracnosis.ToString().ToLower() == val ||
                                v.ResistenciaNematodos.ToString().ToLower() == val
                            );
                            break;
                    }
                }
            }

            return query.ToList(); // Ejecuta la consulta y devuelve la lista de variedades filtradas
        }
    }
}