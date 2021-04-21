using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GestorGenealogico.Data.Modelo
{
    public partial class Genealogia
    {
        [Key]
        public int Id { get; set; }
        public int IdPersona1 { get; set; }
        public int IdPersona2 { get; set; }
        public int IdTipoParentesco { get; set; }

        [ForeignKey(nameof(IdPersona1))]
        [InverseProperty(nameof(Persona.GenealogiaIdPersona1Navigation))]
        public virtual Persona IdPersona1Navigation { get; set; }
        [ForeignKey(nameof(IdPersona2))]
        [InverseProperty(nameof(Persona.GenealogiaIdPersona2Navigation))]
        public virtual Persona IdPersona2Navigation { get; set; }
        [ForeignKey(nameof(IdTipoParentesco))]
        [InverseProperty(nameof(TipoParentesco.Genealogia))]
        public virtual TipoParentesco IdTipoParentescoNavigation { get; set; }
    }
}
