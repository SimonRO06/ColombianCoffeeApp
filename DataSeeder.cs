using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Enums;
using ColombianCoffeeApp.src.Shared.Context;

namespace ColombianCoffeeApp
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Variedades.Any())
            {
                var variedades = new[]
                {
                    new CoffeeVariety
                    {
                        NombreComun = "Castillo",
                        NombreCientifico = "Coffea arabica var. Castillo",
                        Descripcion = "Alta resistencia a la roya, porte medio y buena calidad de taza, sencillamente delicioso!.",
                        RutaImagen = "https://entresemillas.com/3569-large_default/cafe-arabica-castillo-semillas.jpg",
                        Porte = PorteVariedad.Alto,
                        TamanoGrano = TamanoGranoVariedad.Grande,
                        AltitudOptima = 1800,
                        Rendimiento = RendimientoVariedad.Alto,
                        CalidadGrano = 5,
                        ResistenciaRoya = RoyaVariedad.Susceptible,
                        ResistenciaAntracnosis = AntracnosisVariedad.Tolerante,
                        ResistenciaNematodos = NematodosVariedad.Resistente,
                        TiempoCosecha = "8 meses",
                        TiempoMaduracion = "6 meses",
                        RecomendacionNutricion = "Fertilización cada 4 meses",
                        DensidadSiembra = "5000 plantas/ha",
                        Historia = "Desarrollada por Cenicafé en Colombia",
                        GrupoGenetico = "Híbrido",
                        Obtentor = "Cenicafé",
                        Familia = "Rubiaceae"
                    },
                    new CoffeeVariety
                    {
                        NombreComun = "Caturra",
                        NombreCientifico = "Coffea arabica var. Caturra",
                        Descripcion = "Variedad compacta con alta densidad de siembra.",
                        RutaImagen = "https://revistacta.agrosavia.co/public/journals/2/submission_2846_2152_coverImage_es_ES.jpg",
                        Porte = PorteVariedad.Bajo,
                        TamanoGrano = TamanoGranoVariedad.Mediano,
                        AltitudOptima = 1500,
                        Rendimiento = RendimientoVariedad.Medio,
                        CalidadGrano = 5,
                        ResistenciaRoya = RoyaVariedad.Tolerante,
                        ResistenciaAntracnosis = AntracnosisVariedad.Resistente,
                        ResistenciaNematodos = NematodosVariedad.Resistente,
                        TiempoCosecha = "9 meses",
                        TiempoMaduracion = "7 meses",
                        RecomendacionNutricion = "Fertilización cada 6 meses",
                        DensidadSiembra = "6000 plantas/ha",
                        Historia = "Originaria de Brasil",
                        GrupoGenetico = "Típica",
                        Obtentor = "Productores brasileños",
                        Familia = "Rubiaceae"
                    },
                    new CoffeeVariety
                    {
                        NombreComun = "Bourbon",
                        NombreCientifico = "Coffea arabica var. Bourbon",
                        Descripcion = "Variedad antigua y apreciada por su dulzor y aroma floral.",
                        RutaImagen = "https://www.cafescaracas.com/img/cms/blog/Post-001/cafes-caracas-imagen-06.jpg",
                        Porte = PorteVariedad.Alto,
                        TamanoGrano = TamanoGranoVariedad.Grande,
                        AltitudOptima = 1600,
                        Rendimiento = RendimientoVariedad.Medio,
                        CalidadGrano = 5,
                        ResistenciaRoya = RoyaVariedad.Susceptible,
                        ResistenciaAntracnosis = AntracnosisVariedad.Tolerante,
                        ResistenciaNematodos = NematodosVariedad.Susceptible,
                        TiempoCosecha = "9-10 meses",
                        TiempoMaduracion = "7 meses",
                        RecomendacionNutricion = "Fertilizar con abonos ricos en potasio y nitrógeno cada 5 meses",
                        DensidadSiembra = "4500 plantas/ha",
                        Historia = "Originaria de la isla de Bourbon, cultivada ampliamente en América Latina.",
                        GrupoGenetico = "Típica",
                        Obtentor = "Cultivadores tradicionales",
                        Familia = "Rubiaceae"
                    },
                    new CoffeeVariety
                    {
                        NombreComun = "Geisha",
                        NombreCientifico = "Coffea arabica var. Geisha",
                        Descripcion = "Reconocida mundialmente por su perfil floral y afrutado, de altísimo valor en el mercado.",
                        RutaImagen = "https://perfectdailygrind.com/es/wp-content/uploads/sites/2/2016/09/Frutos-de-cafe-Geisha.jpg",
                        Porte = PorteVariedad.Alto,
                        TamanoGrano = TamanoGranoVariedad.Grande,
                        AltitudOptima = 1900,
                        Rendimiento = RendimientoVariedad.Medio,
                        CalidadGrano = 5,
                        ResistenciaRoya = RoyaVariedad.Susceptible,
                        ResistenciaAntracnosis = AntracnosisVariedad.Susceptible,
                        ResistenciaNematodos = NematodosVariedad.Susceptible,
                        TiempoCosecha = "10-11 meses",
                        TiempoMaduracion = "8 meses",
                        RecomendacionNutricion = "Fertilización ligera y frecuente para conservar el perfil de taza",
                        DensidadSiembra = "4000 plantas/ha",
                        Historia = "Originaria de Etiopía, popularizada en Panamá y Colombia por su alta calidad.",
                        GrupoGenetico = "Etíope",
                        Obtentor = "Productores de Panamá",
                        Familia = "Rubiaceae"
                    },
                    new CoffeeVariety
                    {
                        NombreComun = "Tabi",
                        NombreCientifico = "Coffea arabica var. Tabi",
                        Descripcion = "Variedad colombiana resistente a la roya y con excelente calidad en taza.",
                        RutaImagen = "https://farallonesdelcitara.bioexploradores.com/wp-content/uploads/2022/10/IMG_3619-2-1201x631.jpg",
                        Porte = PorteVariedad.Alto,
                        TamanoGrano = TamanoGranoVariedad.Grande,
                        AltitudOptima = 1750,
                        Rendimiento = RendimientoVariedad.Alto,
                        CalidadGrano = 5,
                        ResistenciaRoya = RoyaVariedad.Resistente,
                        ResistenciaAntracnosis = AntracnosisVariedad.Tolerante,
                        ResistenciaNematodos = NematodosVariedad.Resistente,
                        TiempoCosecha = "8-9 meses",
                        TiempoMaduracion = "6 meses",
                        RecomendacionNutricion = "Aplicar fertilización integral con micronutrientes cada 4 meses",
                        DensidadSiembra = "5000 plantas/ha",
                        Historia = "Desarrollada por Cenicafé como respuesta a la roya, conservando la calidad de Típica y Bourbon.",
                        GrupoGenetico = "Híbrido",
                        Obtentor = "Cenicafé",
                        Familia = "Rubiaceae"
                    }
                };

                context.Variedades.AddRange(variedades);
                context.SaveChanges();
                Console.WriteLine("✅ Datos iniciales insertados en la base de datos.");
            }
            else
            {
                Console.WriteLine("ℹ️ Datos ya existentes en la base de datos.");
            }
        }
    }
}