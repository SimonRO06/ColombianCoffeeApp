using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Varieties.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ColombianCoffeeApp.src.Shared.Configurations
{
    public class VarietyConfiguration : IEntityTypeConfiguration<CoffeeVariety>
    {
        public void Configure(EntityTypeBuilder<CoffeeVariety> builder)
        {
            builder.ToTable("variedad");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.NombreComun)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Descripcion)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(v => v.NombreCientifico)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(v => v.RutaImagen)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(v => v.Porte)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(v => v.TamanoGrano)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(v => v.AltitudOptima)
                .IsRequired();

            builder.Property(v => v.Rendimiento)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(v => v.CalidadGrano)
                .IsRequired();

            builder.Property(v => v.ResistenciaRoya)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(v => v.ResistenciaAntracnosis)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(v => v.ResistenciaNematodos)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(v => v.TiempoCosecha)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.TiempoMaduracion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.RecomendacionNutricion)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(v => v.DensidadSiembra)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Historia)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(v => v.GrupoGenetico)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Obtentor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Familia)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}