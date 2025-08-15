using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Enums;

namespace ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities
{

    [Table("variedad")]
    public class CoffeeVariety
    {
        public int Id { get; set; }
        public string? NombreComun { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreCientifico { get; set; }
        public string? RutaImagen { get; set; }
        public PorteVariedad Porte { get; set; }
        public TamanoGranoVariedad TamanoGrano { get; set; } 
        public int AltitudOptima { get; set; }
        public RendimientoVariedad Rendimiento { get; set; }
        public int CalidadGrano { get; set; } 
        public RoyaVariedad ResistenciaRoya { get; set; } 
        public AntracnosisVariedad ResistenciaAntracnosis { get; set; }
        public NematodosVariedad ResistenciaNematodos { get; set; }
        public string? TiempoCosecha { get; set; }
        public string? TiempoMaduracion { get; set; }
        public string? RecomendacionNutricion { get; set; }
        public string? DensidadSiembra { get; set; }
        public string? Historia { get; set; }
        public string? GrupoGenetico { get; set; }
        public string? Obtentor { get; set; }
        public string? Familia { get; set; }
    }
}