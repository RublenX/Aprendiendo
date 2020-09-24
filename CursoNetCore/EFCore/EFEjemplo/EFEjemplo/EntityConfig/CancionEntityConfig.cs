using EFEjemplo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFEjemplo.EntityConfig
{
    public class CancionEntityConfig
    {
        public static void SetCancionEntityConfig(EntityTypeBuilder<Cancion> entityBuilder)
        {
            entityBuilder.HasKey(c => c.CancionId);
            entityBuilder.Property(c => c.Titulo).IsRequired();
            entityBuilder.Property(c => c.Descripcion).HasMaxLength(100);
        }
    }
}
