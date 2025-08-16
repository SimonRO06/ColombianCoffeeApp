using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.IO;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Color = iText.Kernel.Colors.Color;

namespace ColombianCoffeeApp.src.Services
{
    public class PdfService
    {
        Color grisClaro = new DeviceRgb(230, 230, 230);
        public void GenerarCatalogo(List<CoffeeVariety> variedades, string rutaArchivo)
        {
            if (variedades == null || variedades.Count == 0)
            {
                Console.WriteLine("⚠ No hay variedades para generar el catálogo.");
                return;
            }

            Console.WriteLine("\n📋 Variedades disponibles:");
            foreach (var v in variedades)
                Console.WriteLine($"ID: {v.Id} | {v.NombreComun} ({v.NombreCientifico})");

            Console.Write("\nIngrese los IDs de las variedades a incluir (separados por coma): ");
            string? idsInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idsInput))
            {
                Console.WriteLine("⚠ No se seleccionaron variedades.");
                return;
            }

            List<int> idsSeleccionados = idsInput
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(id => int.TryParse(id.Trim(), out int val) ? val : -1)
                .Where(id => id > 0)
                .ToList();

            var variedadesFiltradas = variedades
                .Where(v => idsSeleccionados.Contains(v.Id))
                .ToList();

            if (variedadesFiltradas.Count == 0)
            {
                Console.WriteLine("⚠ No se encontraron variedades con esos IDs.");
                return;
            }

            var brownColor = new DeviceRgb(101, 67, 33);
            PdfFont italicFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            using (var writer = new PdfWriter(rutaArchivo))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf))
            {
                // Portada
                document.Add(new Paragraph("Catálogo de Variedades de Café Colombiano")
                    .SetFont(boldFont)
                    .SetFontSize(28)
                    .SetFontColor(brownColor)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(200));

                document.Add(new Paragraph("Ficha Técnica de Variedades Cultivadas de Café en Colombia")
                    .SetFont(italicFont)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(15));

                document.Add(new Paragraph("Integrantes: ")
                    .SetFont(boldFont)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(40));

                document.Add(new Paragraph("Camilo Andrés Suárez Niño\nFabio Andrés Hernández Manrrique\nJuan Sebastián Mora Patiño\nSimón Rubiano Ortiz")
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(10));

                document.Add(new Paragraph("Docente: ")
                    .SetFont(boldFont)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(40));

                document.Add(new Paragraph("Johlver Pardo")
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(10));

                document.Add(new AreaBreak());

                foreach (var variedad in variedadesFiltradas)
                {
                    // Título centrado
                    document.Add(new Paragraph($"{variedad.NombreComun} ({variedad.NombreCientifico})")
                        .SetFont(boldFont)
                        .SetFontSize(18)
                        .SetMarginTop(50)
                        .SetFontColor(ColorConstants.BLACK)
                        .SetTextAlignment(TextAlignment.CENTER));

                    // Imagen
                    if (!string.IsNullOrWhiteSpace(variedad.RutaImagen))
                    {
                        try
                        {
                            byte[] imageBytes;

                            if (variedad.RutaImagen.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                            {
                                var handler = new HttpClientHandler
                                {
                                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                                };
                                using var httpClient = new HttpClient(handler);
                                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
                                imageBytes = httpClient.GetByteArrayAsync(variedad.RutaImagen).Result;
                            }
                            else if (File.Exists(variedad.RutaImagen))
                            {
                                imageBytes = File.ReadAllBytes(variedad.RutaImagen);
                            }
                            else
                            {
                                throw new Exception("Ruta inválida o archivo inexistente.");
                            }

                            var img = new Image(ImageDataFactory.Create(imageBytes))
                                .SetWidth(200)
                                .SetHeight(150)
                                .SetMarginBottom(10)
                                .SetHorizontalAlignment(HorizontalAlignment.CENTER);

                            document.Add(img);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"⚠ Error cargando imagen '{variedad.RutaImagen}': {ex.Message}");
                            document.Add(new Paragraph("[⛔ Imagen no disponible]")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(10));
                        }
                    }

                    document.Add(new Paragraph("Tabla de Datos: ")
                        .SetFont(boldFont)
                        .SetFontSize(16)
                        .SetFontColor(brownColor));

                    Table tablaDatos = new Table(new float[] { 170f, 330f }).UseAllAvailableWidth();
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Descripción").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.Descripcion).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Porte").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.Porte.ToString()).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Tamaño de Grano").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.TamanoGrano.ToString()).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Altitud Óptima").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph($"{variedad.AltitudOptima} msnm").SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Potencial de Rendimiento").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.Rendimiento.ToString()).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Calidad del Grano").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph($"{variedad.CalidadGrano}/5").SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Roya").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.ResistenciaRoya.ToString()).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Antracnosis").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.ResistenciaAntracnosis.ToString()).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Nematodos").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.ResistenciaNematodos.ToString()).SetFont(italicFont)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Historia").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.Historia)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Grupo Genético").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.GrupoGenetico)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Obtentor").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.Obtentor)));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph("Familia").SetFont(boldFont)).SetBackgroundColor(grisClaro));
                    tablaDatos.AddCell(new Cell().Add(new Paragraph(variedad.Familia)));
                    document.Add(tablaDatos);
                    document.Add(new LineSeparator(new SolidLine())
                        .SetMargins(80, 0, 50, 0));
                        }
            }
            Console.WriteLine($"✅ Catálogo PDF generado correctamente:");
            Console.Write("Enlace: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Path.GetFullPath(rutaArchivo));
            Console.ResetColor();
        }
    }
}