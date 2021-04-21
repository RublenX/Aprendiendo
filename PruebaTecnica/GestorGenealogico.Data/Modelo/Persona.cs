using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GestorGenealogico.Data.Modelo
{
    public partial class Persona
    {
        public Persona()
        {
            GenealogiaIdPersona1Navigation = new HashSet<Genealogia>();
            GenealogiaIdPersona2Navigation = new HashSet<Genealogia>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Nacimiento { get; set; }

        [InverseProperty(nameof(Genealogia.IdPersona1Navigation))]
        public virtual ICollection<Genealogia> GenealogiaIdPersona1Navigation { get; set; }
        [InverseProperty(nameof(Genealogia.IdPersona2Navigation))]
        public virtual ICollection<Genealogia> GenealogiaIdPersona2Navigation { get; set; }
    }
}
